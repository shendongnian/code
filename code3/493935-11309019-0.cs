    public class MailboxInformation : IDisposeable
    {
       //...
       public SecureString Password { get; set; }
       //...
       void IDisposable.Dispose() {
          this.Password.Dispose();
       }
    }
