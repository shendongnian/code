    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Dts.Runtime;
    
    //using System.Data.OleDb;
    
    namespace AOC.SqlServer.Dts.Tasks
    {
        [DtsTask(
            DisplayName = "Custom Logging Task",
            Description = "Writes logging info into a table")]
        public class CustomLoggingTask : Task
        {
            private string _packageName;
            private string _taskName;
            private string _errorCode;
            private string _errorDescription;
            private string _machineName;
            private double _packageDuration;
    
            private string _connectionName;
            private string _eventType;
            private string _executionid;
            private DateTime _handlerdatetime;
            private string _uid;
    
            public string ConnectionName
            {
                set { _connectionName = value; }
                get { return _connectionName; }
            }
    
            public string Event
            {
                set { _eventType = value; }
                get { return _eventType; }
            }
    
            private DbConnection _connection;
    
            public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log)
            {
                const string METHOD_NAME = "CustomLoggingTask-Validate";
    
                try
                {
                    if (string.IsNullOrEmpty(_eventType))
                    {
                        componentEvents.FireError(0, METHOD_NAME, "The event property must be specified", "", -1);
                        return DTSExecResult.Failure;
                    }
    
                    if (string.IsNullOrEmpty(_connectionName))
                    {
                        componentEvents.FireError(0, METHOD_NAME, "No connection has been specified", "", -1);
                        return DTSExecResult.Failure;
                    }
    
                    //SqlConnection connection = connections[_connectionName].AcquireConnection(null) as SqlConnection;
                    _connection = connections[_connectionName].AcquireConnection(null) as DbConnection;
    
                    if (_connection == null)
                    {
                        ConnectionManager cm = connections[_connectionName];
                        Microsoft.SqlServer.Dts.Runtime.Wrapper.IDTSConnectionManagerDatabaseParameters100 cmParams = cm.InnerObject as Microsoft.SqlServer.Dts.Runtime.Wrapper.IDTSConnectionManagerDatabaseParameters100;
                        _connection = cmParams.GetConnectionForSchema() as OleDbConnection;
    
                        if (_connection == null)
                        {
                            componentEvents.FireError(0, METHOD_NAME, "The connection is not a valid ADO.NET or OLEDB connection", "", -1);
                            return DTSExecResult.Failure;
                        }
                    }
    
                    if (!variableDispenser.Contains("System::SourceID"))
                    {
                        componentEvents.FireError(0, METHOD_NAME, "No System::SourceID variable available. This task can only be used in an Event Handler", "", -1);
                        return DTSExecResult.Failure;
                    }
    
                    return DTSExecResult.Success;
                }
                catch (Exception exc)
                {
                    componentEvents.FireError(0, METHOD_NAME, "Validation Failed: " + exc.ToString(), "", -1);
                    return DTSExecResult.Failure;
                }
            }
    
            public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log, object transaction)
            {
                try
                {
                    string commandText = null;
    
                    ReadVariables(variableDispenser);
                    //DbConnection connection = connections[_connectionName].AcquireConnection(transaction) as DbConnection;
                    //SqlConnection connection = (SqlConnection)connections[_connectionName].AcquireConnection(transaction);
                    DbCommand command = null;
    
                    //using (SqlCommand command = new SqlCommand())
                    if (_connection is SqlConnection)
                    {
                        commandText = @"INSERT INTO SSISLog (EventType, PackageName, TaskName, EventCode, EventDescription, PackageDuration, Host, ExecutionID, EventHandlerDateTime,UID)
                                        VALUES (@EventType, @PackageName, @TaskName, @EventCode, @EventDescription, @PackageDuration, @Host, @Executionid, @handlerdatetime,@uid)";
    
                        command = new SqlCommand();
    
                        command.Parameters.Add(new SqlParameter("@EventType", _eventType));
                        command.Parameters.Add(new SqlParameter("@PackageName", _packageName));
                        command.Parameters.Add(new SqlParameter("@TaskName", _taskName));
                        command.Parameters.Add(new SqlParameter("@EventCode", _errorCode ?? string.Empty));
                        command.Parameters.Add(new SqlParameter("@EventDescription", _errorDescription ?? string.Empty));
                        command.Parameters.Add(new SqlParameter("@PackageDuration", _packageDuration));
                        command.Parameters.Add(new SqlParameter("@Host", _machineName));
                        command.Parameters.Add(new SqlParameter("@ExecutionID", _executionid));
                        command.Parameters.Add(new SqlParameter("@handlerdatetime", _handlerdatetime));
                        command.Parameters.Add(new SqlParameter("@uid", _uid));
                    }
                    else if (_connection is OleDbConnection)
                    {
                        commandText = @"INSERT INTO SSISLog (EventType,PackageName,TaskName,EventCode,EventDescription,PackageDuration,Host,ExecutionID,EventHandlerDateTime,UID)
                                        VALUES (?,?,?,?,?,?,?,?,?,?)";
    
                        command = new OleDbCommand();
    
                        command.Parameters.Add(new OleDbParameter("@EventType", _eventType));
                        command.Parameters.Add(new OleDbParameter("@PackageName", _packageName));
                        command.Parameters.Add(new OleDbParameter("@TaskName", _taskName));
                        command.Parameters.Add(new OleDbParameter("@EventCode", _errorCode ?? string.Empty));
                        command.Parameters.Add(new OleDbParameter("@EventDescription", _errorDescription ?? string.Empty));
                        command.Parameters.Add(new OleDbParameter("@PackageDuration", _packageDuration));
                        command.Parameters.Add(new OleDbParameter("@Host", _machineName));
                        command.Parameters.Add(new OleDbParameter("@ExecutionID", _executionid));
                        command.Parameters.Add(new OleDbParameter("@handlerdatetime", _handlerdatetime));
                        command.Parameters.Add(new OleDbParameter("@uid", _uid));
                    }
    
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    command.Connection = _connection;
    
                    command.ExecuteNonQuery();
                    _connection.Close();
                    return DTSExecResult.Success;
    
                }
                catch (Exception exc)
                {
                    componentEvents.FireError(0, "CustomLoggingTask-Execute", "Task Errored: " + exc.ToString(), "", -1);
                    return DTSExecResult.Failure;
                }
            }
    
            private void ReadVariables(VariableDispenser variableDispenser)
            {
                variableDispenser.LockForRead("System::StartTime");
                variableDispenser.LockForRead("System::PackageName");
                variableDispenser.LockForRead("System::SourceName");
                variableDispenser.LockForRead("System::MachineName");
                variableDispenser.LockForRead("System::ExecutionInstanceGUID");
                variableDispenser.LockForRead("System::EventHandlerStartTime");
                variableDispenser.LockForRead("User::UID");
                bool includesError = variableDispenser.Contains("System::ErrorCode");
                if (includesError)
                {
                    variableDispenser.LockForRead("System::ErrorCode");
                    variableDispenser.LockForRead("System::ErrorDescription");
                }
    
                Variables vars = null;
                variableDispenser.GetVariables(ref vars);
    
                DateTime startTime = (DateTime)vars["System::StartTime"].Value;
                _packageDuration = DateTime.Now.Subtract(startTime).TotalSeconds;
                _packageName = vars["System::PackageName"].Value.ToString();
                _taskName = vars["System::SourceName"].Value.ToString();
                _machineName = vars["System::MachineName"].Value.ToString();
                _executionid = vars["System::ExecutionInstanceGUID"].Value.ToString();
                _handlerdatetime = (DateTime)vars["System::EventHandlerStartTime"].Value;
                _uid = vars["User::UID"].Value.ToString();
                if (includesError)
                {
                    _errorCode = vars["System::ErrorCode"].Value.ToString();
                    _errorDescription = vars["System::ErrorDescription"].Value.ToString();
                }
    
                // release the variable locks.
                vars.Unlock();
    
                // reset the dispenser
                variableDispenser.Reset();
            }
        }
    }
