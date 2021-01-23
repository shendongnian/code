    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Data.OleDb;
    using System.Data.Odbc;
    using System.IO;
    using System.ComponentModel;
    
    namespace dal
    {
    
        /// <summary>
        /// Summary description for Data Access Layer
        /// </summary>
        public class DataAccess
        {
            public string strConnectionString;
            private DbConnection objConnection;
            private DbCommand objCommand;
            private DbProviderFactory objFactory = null;
            private bool boolHandleErrors=false;
            private string strLastError;
            private bool boolLogError=false;
            private string strLogFile;
    
            public DataAccess()
            {
    
                //strConnectionString = ;
                strConnectionString = objCommon.GetConnectionString;
                objFactory = OleDbFactory.Instance;
                objConnection = objFactory.CreateConnection();
                objCommand = objFactory.CreateCommand();
                objConnection.ConnectionString = strConnectionString;
                objCommand.Connection = objConnection;
            }
    
            public bool HandleErrors
            {
                get
                {
                    return boolHandleErrors;
                }
                set
                {
                    boolHandleErrors = value;
                }
            }
    
            public string LastError
            {
                get
                {
                    return strLastError;
                }
            }
    
            public bool LogErrors
            {
                get
    -            {
                    return boolLogError;
                }
                set
                {
                    boolLogError = value;
                }
            }
    
            public string LogFile
            {
                get
                {
                    return strLogFile;
                }
                set
                {
                    strLogFile = value;
                }
            }
    
            public int AddParameter(string name, object value)
            {
                DbParameter p = objFactory.CreateParameter();
                p.ParameterName = name;
                p.Value = value;
                return objCommand.Parameters.Add(p);
            }
    
            public int AddParameter(string name, object value, ParameterDirection direction)
            {
                DbParameter p = objFactory.CreateParameter();
                p.ParameterName = name;
                p.Value = value;
                p.Direction = direction;
                return objCommand.Parameters.Add(p);
            }
    
            public int AddParameter(string name, object value, DbType type)
            {
                DbParameter p = objFactory.CreateParameter();
                p.ParameterName = name;
                p.Value = value;
                p.DbType = type;
                return objCommand.Parameters.Add(p);
            }
    
            public int AddParameter(DbParameter parameter)
            {
                return objCommand.Parameters.Add(parameter);
            }
    
            public DbCommand Command
            {
                get
                {
                    return objCommand;
                }
            }
    
            public void BeginTransaction()
            {
                try
                {
                    if (objConnection.State == System.Data.ConnectionState.Closed)
                    {
                        objConnection.Open();
                    }
                    objCommand.Transaction = objConnection.BeginTransaction();
                }
                catch (Exception Ex)
                {
                    HandleExceptions(Ex);
                }
            }
    
            public void CommitTransaction()
            {
                objCommand.Transaction.Commit();
                objConnection.Close();
            }
    
            public void RollbackTransaction()
            {
                objCommand.Transaction.Rollback();
                objConnection.Close();
            }
    
            public int ExecuteNonQuery(string query)
            {
                return ExecuteNonQuery(query, CommandType.Text, ConnectionState.CloseOnExit);
            }
    
            public int ExecuteNonQuery(string query, CommandType commandtype)
            {
                return ExecuteNonQuery(query, commandtype, ConnectionState.CloseOnExit);
            }
    
            public int ExecuteNonQuery(string query, ConnectionState connectionstate)
            {
                return ExecuteNonQuery(query, CommandType.Text, connectionstate);
            }
    
            public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState connectionstate)
            {
                objCommand.CommandText = query;
                objCommand.CommandType = commandtype;
                int i = -1;
                try
                {
                    if (objConnection.State == System.Data.ConnectionState.Closed)
                    {
                        objConnection.Open();
                    }
                    i = objCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    HandleExceptions(ex);
                }
                finally
                {
                    objCommand.Parameters.Clear();
                    if (connectionstate == ConnectionState.CloseOnExit)
                    {
                        objConnection.Close();
                    }
                }
    
                return i;
            }
    
            public object ExecuteScalar(string query)
            {
                return ExecuteScalar(query, CommandType.Text, ConnectionState.CloseOnExit);
            }
    
            public object ExecuteScalar(string query, CommandType commandtype)
            {
                return ExecuteScalar(query, commandtype, ConnectionState.CloseOnExit);
            }
    
            public object ExecuteScalar(string query, ConnectionState connectionstate)
            {
                return ExecuteScalar(query, CommandType.Text, connectionstate);
            }
    
            public object ExecuteScalar(string query, CommandType commandtype, ConnectionState connectionstate)
            {
                objCommand.CommandText = query;
                objCommand.CommandType = commandtype;
                object o = null;
                try
                {
                    if (objConnection.State == System.Data.ConnectionState.Closed)
                    {
                        objConnection.Open();
                    }
                    o = objCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    HandleExceptions(ex);
                }
                finally
                {
                    objCommand.Parameters.Clear();
                    if (connectionstate == ConnectionState.CloseOnExit)
                    {
                        objConnection.Close();
                    }
                }
    
                return o;
            }
    
            public DbDataReader ExecuteReader(string query)
            {
                return ExecuteReader(query, CommandType.Text, ConnectionState.CloseOnExit);
            }
    
            public DbDataReader ExecuteReader(string query, CommandType commandtype)
            {
                return ExecuteReader(query, commandtype, ConnectionState.CloseOnExit);
            }
    
            public DbDataReader ExecuteReader(string query, ConnectionState connectionstate)
            {
                return ExecuteReader(query, CommandType.Text, connectionstate);
            }
    
            public DbDataReader ExecuteReader(string query, CommandType commandtype, ConnectionState connectionstate)
            {
                objCommand.CommandText = query;
                objCommand.CommandType = commandtype;
                DbDataReader reader = null;
                try
                {
                    if (objConnection.State == System.Data.ConnectionState.Closed)
                    {
                        objConnection.Open();
                    }
                    if (connectionstate == ConnectionState.CloseOnExit)
                    {
                        reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    else
                    {
                        reader = objCommand.ExecuteReader();
                    }
    
                }
                catch (Exception ex)
                {
                    HandleExceptions(ex);
                }
                finally
                {
                    objCommand.Parameters.Clear();
                }
    
                return reader;
            }
    
            public DataSet ExecuteDataSet(string query)
            {
                return ExecuteDataSet(query, CommandType.Text, ConnectionState.CloseOnExit);
            }
    
            public DataSet ExecuteDataSet(string query, CommandType commandtype)
            {
                return ExecuteDataSet(query, commandtype, ConnectionState.CloseOnExit);
            }
    
            public DataSet ExecuteDataSet(string query, ConnectionState connectionstate)
            {
                return ExecuteDataSet(query, CommandType.Text, connectionstate);
            }
    
            public DataSet ExecuteDataSet(string query, CommandType commandtype, ConnectionState connectionstate)
            {
                DbDataAdapter adapter = objFactory.CreateDataAdapter();
                objCommand.CommandText = query;
                objCommand.CommandType = commandtype;
                adapter.SelectCommand = objCommand;
                DataSet ds = new DataSet();
                
                try
                {
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    HandleExceptions(ex);
                }
                finally
                {
                    objCommand.Parameters.Clear();
                    if (connectionstate == ConnectionState.CloseOnExit)
                    {
                        if (objConnection.State == System.Data.ConnectionState.Open)
                        {
                            objConnection.Close();
                        }
                    }
                }
                return ds;
            }
    
            private void HandleExceptions(Exception ex)
            {
    
                throw ex;
    
            }
    
            private void WriteToLog(string msg)
            {
                StreamWriter writer = File.AppendText(LogFile);
                writer.WriteLine(DateTime.Now.ToString() + " - " + msg);
                writer.Close();
            }
    
            public void Dispose()
            {
                objConnection.Close();
                objConnection.Dispose();
                objCommand.Dispose();
            }
    
    
    
            public enum Providers
            {
                SqlServer, OleDb, Oracle, ODBC, ConfigDefined
            }
    
            public enum ConnectionState
            {
                KeepOpen, CloseOnExit
            }
    
            public interface ILoadFromDataRow
            {
                bool LoadFromDataRow(DataRow row);
            }
    
    
        }
    
    }
