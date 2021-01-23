    public class PrinterSettings {
        public string Password { get; set; }
        public int Port { get; set; }
        /* .. others .. */
    }
    public interface IPrinterProvider {
        void Initialize(PrinterSettings settings);
        bool Connect(string comPort);
        bool IsConnected();
    }
