    public interface IPrinterProvider
    {
        bool Connect(string comPort);
        bool IsConnected();
    }
    public interface IPasswordPrinterProvider : IPrinterProvider
    {
        string Password { get; set; }
    }
