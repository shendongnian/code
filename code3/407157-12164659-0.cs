        [WebMethod]
        public void MyServerMethod()
        {
            try
            {
                //open connection and execute your calls to Oracle DB...
            }
            catch (Exception ex)
            {
                LogServiceException(ex);
                throw ex;
            }
        }
        void LogServiceException(Exception ex)
        {
            string fullMessage = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                fullMessage += " Inner exception: " + ex.Message;
            }
            //log your exception to log file, DB or eventlog...
            //in this case I will use log file, just make sure you appropriate filesystem rights to do this...
            System.IO.File.AppendAllText("LogFile.txt", fullMessage);
        }
