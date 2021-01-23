    public static class MailMessageExtensions
        {
        public static string  RawMessage(this MailMessage m)
            {
            var smtpClient = new SmtpClient { DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory };
            using (var tempDir = new TemporaryDirectory())
                {
                smtpClient.PickupDirectoryLocation = tempDir.DirectoryPath;
                smtpClient.Send( m );
                var emlFile = Directory.GetFiles( smtpClient.PickupDirectoryLocation ).FirstOrDefault();
                if ( emlFile != null )
                    {
                    return File.ReadAllText( emlFile );
                    }
                else
                    return null;
                }
            return null;
            }
        }
    class TemporaryDirectory : IDisposable
        {
        public TemporaryDirectory()
            {
            DirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory( DirectoryPath );
            }
        public string DirectoryPath { get; private set; }
        public void Dispose()
            {
            if ( Directory.Exists( DirectoryPath ) )
                Directory.Delete( DirectoryPath, true );
            }
        }
