    public class SmtpClientAdapter : ISmtpClient
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SmtpClientAdapter));
    
        private bool disposed;
    
        private SmtpClient smtpClient = new SmtpClient();
    
        public SendResult Send(MailMessage message)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
    
            try
            {
                smtpClient.Send(message);
                return SendResult.Successful;
            }
            catch (Exception e)
            {
                log.Error(e);
                return new SendResult(false, e.Message);
            }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
    
            if (disposing)
            {
                if (smtpClient != null)
                {
                    smtpClient.Dispose();
                    smtpClient = null;
                }
            }
    
            disposed = true;
        }
    }
