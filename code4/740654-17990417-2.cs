    public class PrinterCompany2:PrinterProvider
    {
        // Printer that doesnt need password
        public override bool connect(string port)
        {
            return false;
        }
    }
