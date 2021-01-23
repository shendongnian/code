        [WebMethod]
        public void XMLPersing()
        {
            var XMLDATA = "";
            WriteLogCLS objWriteLog = new WriteLogCLS();
            Stream receiveStream = HttpContext.Current.Request.InputStream;
            receiveStream.Position = 0;
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);      //For xml persing..
            XMLDATA = readStream.ReadToEnd();
            readStream.Close();
          objWriteLog.WriteLog(Convert.ToString(XMLDATA));
            XmlTextReader xmlreader = new XmlTextReader(Server.MapPath("Log/Exception/Sample.xml"));
            DataSet ds = new DataSet();
            ds.ReadXml(xmlreader);
            xmlreader.Close();
            if (ds.Tables.Count != 0)
            {
                var strCon = string.Empty;
                strCon = ConfigurationManager.AppSettings["constring"];
                SqlCommand cmdInsertXMLData = new SqlCommand();
                SqlConnection SqlConn;
                SqlConn = new SqlConnection(strCon);
                try
                {
                    cmdInsertXMLData = new SqlCommand("usp_InsertXML", SqlConn);
                    cmdInsertXMLData.CommandType = CommandType.StoredProcedure;
                    // cmdInsertLoginDetails.Parameters.Add("@XMLdata", SqlDbType.Xml).Value = ds.GetXml();
                    cmdInsertXMLData.Parameters.AddWithValue("@XMLdata", SqlDbType.Xml);
                    if (SqlConn.State == ConnectionState.Closed)
                    {
                        SqlConn.Open();
                    }
                    cmdInsertXMLData.ExecuteNonQuery();
                    // response = cmdInsertLoginDetails.Parameters["@Message"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objWriteLog.WriteLog("Error on XML Persing : " + ex.Message);
                    // response = "Error";
                }
                finally
                {
                    if (cmdInsertXMLData != null)
                    {
                        cmdInsertXMLData.Dispose();
                    }
                    if (SqlConn.State == ConnectionState.Open)
                    {
                        SqlConn.Close();
                        SqlConn.Dispose();
                    }
                    objWriteLog = null;
                }
                // return response  ;
            }
        }
    }
