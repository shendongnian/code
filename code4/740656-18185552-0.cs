    public class PasswordPrinterProvider : IPrinterProvider
    {
         private readonly string password;
         public PasswordPrinterProvider(string password)
         {
             this.password = password;
         }
         public bool Connect(string comPort) {...}
         public bool IsConnected() {...}
    }
