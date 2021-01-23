        public DataTable DoSomeSql(int retryCount = 1)
        {
            try
            {
                //Run Stored Proc/Adhoc SQL here
            }
            catch (SqlException sqlEx)
            {
                if (retryCount == MAX_RETRY_COUNT) //5, 7, Whatever
                {
                    log.Error("Unable to DoSomeSql, reached maximum number of retries.");
                    throw;
                }
                switch (sqlEx.Number)
                {
                    case DBConstants.SQL_DEADLOCK_ERROR_CODE: //1205
                        log.Warn("DoSomeSql was deadlocked, will try again.");
                        break;
                    case DBConstants.SQL_TIMEOUT_ERROR_CODE: //-2
                        log.Warn("DoSomeSql was timedout, will try again.");
                        break;
                    default:
                        log.WarnFormat(buf.ToString(), sqlEx);
                        break;
                }
                System.Threading.Thread.Sleep(1000); //Can also use Math.Rand for a random interval of time
                return DoSomeSql(asOfDate, ++retryCount);
            }
        }
