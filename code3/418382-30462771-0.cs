    internal class SslStreamEx : System.Net.Security.SslStream
    {
        public override void Close()
        {
            try
            {
                // Send close_notify manually
            }
            finally
            {
                base.Close();
            }
        }
    }
