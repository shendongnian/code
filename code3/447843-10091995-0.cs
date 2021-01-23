    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Web;
    using System.Xml;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Collections.Generic;
    using System.Text;
    
    namespace NESCTC.Data
    {   
        public class DataAccess : IDisposable
        {
            #region declarations
    
            private SqlCommand _cmd;
            private string _SqlConnString;
    
            #endregion
    
            #region constructors
    
            public DataAccess(string ConnectionString)
            {
                _cmd = new SqlCommand();
                _cmd.CommandTimeout = 240;
                _SqlConnString = ConnectionString;
            }
    
            #endregion
    
            #region IDisposable implementation
    
            ~DataAccess()
            {
                Dispose(false);
            }
    
            public void Dispose()
            {
                Dispose(true);            
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _cmd.Connection.Dispose();
                    _cmd.Dispose();
                }
            }
    
            #endregion
    
            #region data retrieval methods
    
            public DataTable ExecReturnDataTable()
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    try
                    {
                        PrepareCommandForExecution(conn);
                        using (SqlDataAdapter adap = new SqlDataAdapter(_cmd))
                        {
                            DataTable dt = new DataTable();
                            adap.Fill(dt);
                            return dt;
                        }
                    }
                    catch
                    {
                        _cmd.Connection.Close();
                        throw;
                    }
                    finally
                    {
                        _cmd.Connection.Close();
                    }
                }
            }    
            
    
            public object ExecScalar()
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    try
                    {
                        PrepareCommandForExecution(conn);
                        return _cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        _cmd.Connection.Close();
                        throw ex;
                    }
                    finally
                    {
                        _cmd.Connection.Close();
                    }
                }
            }
    
            public string ExecReturnXml()
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    try
                    {
                        PrepareCommandForExecution(conn);
                        StringBuilder sbXmlOutput = new StringBuilder();
                        using (XmlReader xDataReader = _cmd.ExecuteXmlReader())
                        {
                            using (XmlWriter writer = XmlWriter.Create(sbXmlOutput))
                            {
                                //write the reader to the writer
                                writer.WriteNode(xDataReader, true);
                            }
                        }
                        //return the xml string
                        return sbXmlOutput.ToString();
                    }
                    catch (Exception ex)
                    {
                        _cmd.Connection.Close();
                        throw ex;
                    }
                    finally
                    {
                        _cmd.Connection.Close();
                    }
                }
            }
    
            #endregion
    
            #region data insert and update methods
    
            public void ExecNonQuery()
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    try
                    {
                        PrepareCommandForExecution(conn);
                        _cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        _cmd.Connection.Close();
                        throw;
                    }
                    finally
                    {
                        _cmd.Connection.Close();
                    }
                }
            }
    
            #endregion
    
            #region helper methods
    
            public void AddParm(string ParameterName, SqlDbType ParameterType, object Value)
            { _cmd.Parameters.Add(ParameterName, ParameterType).Value = Value; }
    
            private SqlCommand PrepareCommandForExecution(SqlConnection conn)
            {
                try
                {
                    _cmd.Connection = conn;
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandTimeout = this.CommandTimeout;
                    _cmd.Connection.Open();
    
                    return _cmd;
                }
                catch
                {
                    _cmd.Connection.Close();
                    throw;
                }
            }
    
            #endregion
    
            #region properties
    
            public int CommandTimeout
            {
                get { return _cmd.CommandTimeout; }
                set { _cmd.CommandTimeout = value; }
            }
    
            public string ProcedureName
            {
                get { return _cmd.CommandText; }
                set { _cmd.CommandText = value; }
            }
    
            public string ConnectionString
            {
                get { return _SqlConnString; }
                set { _SqlConnString = value; }
            }
    
            #endregion
        }
    }
