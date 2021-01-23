    public class LoggingDisposeable : IDisposable
    {
        MySQLProcessing MySQLP;
    
        public LoggingDisposeable()
        {
            MYSQLP = new MySQLProcessing.MySQLProcessor();
        }
    
        public void GenericLogging(string systemMsg, string SystemClass, string SystemSection, string ID, string FixID, string baseURL, string mysqlQueryName, string mysqlQuery)
        {
            string Loggingall = " insert into tblLogs " +
                            "set SystemMsg='" + systemMsg.Replace("'", "''") + "'" +
                            ",SystemClass = '" + SystemClass.Replace("'", "''") + "'" +
                            ",SystemSection = '" + SystemSection.Replace("'", "''") +
                            ",ID = '" + CarID.Replace("'", "''") + "'" +
                            ",FixID = '" + FixID.Replace("'", "''") + "'" +
                            ",baseurl = '" + baseURL.Replace("'", "''") + "'" +
                            ",mysqlqueryName = '" + mysqlQuery.Replace("'", "''") +
                            ",mysqlquery = '" + mysqlQuery.Replace("'", "''") + "'" +
                            ",Site = 'AutoTrader'" +
                            ",TimeStamp = Now()";
                    
                MYSQLP.MySQLInsertUpdate(Loggingall, "Loggingall");                
        }
    
        public void Dispose()
        {
            MYSQLP.Dispose();
        }
    }
