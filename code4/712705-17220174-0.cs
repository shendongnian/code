    using System.Data.SqlClient;
    using System.Xml;
    using Microsoft.SqlServer.Server;
    
    namespace Axis.CLR.SampleObjects
    {
    	using System;
    	using System.Data;
    	using System.Data.SqlTypes;
    	using System.Text;
    
    	public partial class AuditTrigger
    	{
    		public const string GetTableContextStatement =
    			"SELECT object_name(resource_associated_entity_id) FROM sys.dm_tran_locks WHERE request_session_id = @@spid and resource_type = 'OBJECT'";
    
    		[SqlTrigger(Name = "UserNameAudit", Target = "Users", Event = "FOR INSERT")]
    		public static void UserNameAudit()
    		{
    			SqlTriggerContext triggContext = SqlContext.TriggerContext;
    
    			//SqlPipe sqlP = SqlContext.Pipe;
    
    			using (SqlConnection conn = new SqlConnection("context connection=true"))
    			using (SqlCommand sqlComm = conn.CreateCommand())
    			{
    				conn.Open();
    
    				// Gets a reference to the affected table name
    				string tableName = string.Empty;
    				using (SqlCommand cmd = new SqlCommand(GetTableContextStatement, conn))
    				{
    					tableName = cmd.ExecuteScalar().ToString();
    				}
    
    				// STORING INSERT AUDIT
    
    				if (triggContext.TriggerAction == TriggerAction.Insert)
    				{
    					#region handling INSERT action
    
    					sqlComm.CommandText = "SELECT * from INSERTED";
    					var reader = sqlComm.ExecuteReader();
    
    					if (reader.Read())
    					{
    						XmlDocument finalDocument = new XmlDocument();
    
    						XmlNode rootElement = finalDocument.CreateNode(XmlNodeType.Element, tableName, string.Empty);
    
    						XmlAttribute newAttribute = finalDocument.CreateAttribute("Id");
    						newAttribute.Value = reader.GetInt64(reader.GetOrdinal("Id")).ToString();
    						rootElement.Attributes.Append(newAttribute);
    						
    						newAttribute = finalDocument.CreateAttribute("Operation");
    						newAttribute.Value = "INSERT";
    						rootElement.Attributes.Append(newAttribute);
    
    						finalDocument.AppendChild(rootElement);
    
    						XmlNode createdElement = finalDocument.CreateNode(XmlNodeType.Element, "Fields", string.Empty);
    
    						for (int i = 0; i < reader.FieldCount; i++)
    						{
    							XmlNode fieldElement = finalDocument.CreateNode(XmlNodeType.Element, reader.GetName(i), string.Empty);
    
    							if (reader.IsDBNull(i))
    							{
    								fieldElement.InnerText = "NULL";
    							}
    							else
    							{
    								fieldElement.InnerText = reader.GetValue(i).ToString();
    							}
    
    							createdElement.AppendChild(fieldElement);
    						}
    
    						// Node was added
    						rootElement.AppendChild(createdElement);
    
    						// Adds the Audit
    
    						sqlComm.CommandText = "[dbo].[AddAuditTrail]";
    						sqlComm.CommandType = CommandType.StoredProcedure;
    
    						SqlParameter xmlParamA = new SqlParameter("@ObjectId", SqlDbType.BigInt);
    						xmlParamA.Value = reader.GetInt64(reader.GetOrdinal("Id"));
    						sqlComm.Parameters.Add(xmlParamA);
    
    						reader.Close();
    
    						sqlComm.Parameters.AddWithValue("@ObjectName", tableName);
    
    						SqlParameter xmlParamB = new SqlParameter("@TraceXML", SqlDbType.Xml);
    						xmlParamB.Value = new SqlXml(new XmlTextReader(finalDocument.OuterXml, XmlNodeType.Document, null));
    						sqlComm.Parameters.Add(xmlParamB);
    
    						sqlComm.Parameters.AddWithValue("@AuditType", "INSERT");
    
    						sqlComm.ExecuteNonQuery();
    
    						//sqlP.Send(string.Format("Generated AFTER INSERT XML is: '{0}'", finalDocument.OuterXml));
    					}
    
    					#endregion handling INSERT action
    				}
    				else if (triggContext.TriggerAction == TriggerAction.Update)
    				{
    					#region handling UPDATE action
    
    					DataSet values = new DataSet();
    					SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
    
    					sqlComm.CommandText = "SELECT * from INSERTED";
    					adapter.Fill(values, "INSERTED");
    
    					sqlComm.CommandText = "SELECT * from DELETED";
    					adapter.Fill(values, "DELETED");
    
    					StringBuilder builder = new StringBuilder();
    
    					builder.Append("<Fields>");
    
    					int recordId = 0;
    
    					for (int i = 0; i < values.Tables["INSERTED"].Columns.Count; i++)
    					{
    						string colName = values.Tables["INSERTED"].Columns[i].ColumnName;
    
    						if (colName.ToLower().Equals("id"))
    						{
    							recordId = Convert.ToInt32(values.Tables["DELETED"].Rows[0][i]);
    
    							builder.AppendFormat("<Id value='{0}' />", recordId);
    						}
    
    						// if both nulls or both the same, no audit needed...
    
    						if (values.Tables["INSERTED"].Rows[0].IsNull(i) && values.Tables["DELETED"].Rows[0].IsNull(i))
    						{
    							continue;
    						}
    
    						if (values.Tables["INSERTED"].Rows[0][i].Equals(values.Tables["DELETED"].Rows[0][i]))
    						{
    							continue;
    						}
    
    						builder.AppendFormat("<{0}>", colName);
    
    						// DUMPING OLD VALUE
    						builder.Append("<OldValue>");
    
    						if (values.Tables["DELETED"].Rows[0].IsNull(i))
    						{
    							builder.Append("NULL");
    						}
    						else
    						{
    							builder.Append(values.Tables["DELETED"].Rows[0][i]);
    						}
    
    						builder.Append("</OldValue>");
    
    						// DUMPING NEW VALUE
    						builder.Append("<NewValue>");
    
    						if (values.Tables["INSERTED"].Rows[0].IsNull(i))
    						{
    							builder.Append("NULL");
    						}
    						else
    						{
    							builder.Append(values.Tables["INSERTED"].Rows[0][i]);
    						}
    
    						builder.Append("</NewValue>");
    
    						builder.AppendFormat("</{0}>", colName);
    					}
    
    					builder.Append("</Fields>");
    
    					builder.Insert(0, string.Format("<{0} Id='{1}' Operation='{2}'>", tableName, recordId, "UPDATE"));
    					builder.AppendFormat("</{0}>", tableName);
    
    					// Adds the Audit
    
    					sqlComm.CommandText = "[dbo].[AddAuditTrail]";
    					sqlComm.CommandType = CommandType.StoredProcedure;
    
    					SqlParameter xmlParamA = new SqlParameter("@ObjectId", SqlDbType.BigInt);
    					xmlParamA.Value = recordId;
    					sqlComm.Parameters.Add(xmlParamA);
    
    					sqlComm.Parameters.AddWithValue("@ObjectName", tableName);
    
    					SqlParameter xmlParamB = new SqlParameter("@TraceXML", SqlDbType.Xml);
    					xmlParamB.Value = new SqlXml(new XmlTextReader(builder.ToString(), XmlNodeType.Document, null));
    					sqlComm.Parameters.Add(xmlParamB);
    
    					sqlComm.Parameters.AddWithValue("@AuditType", "UPDATE");
    
    					sqlComm.ExecuteNonQuery();
    
    					//sqlP.Send(string.Format("Generated AFTER UPDATE XML is: '{0}'", builder.ToString()));
    
    					#endregion handling UPDATE action
    				}
    			}
    		}
    	}
    }
