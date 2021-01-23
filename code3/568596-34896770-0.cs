    class PrinterInstaller
    {
        private static readonly HashSet<string> PrinterNames = new HashSet<string>
            {
                "jupiter", "neptune", "pangea", "mercury", "sonic"
            };
        public void Setup(string printerName)
        {
            if (!PrinterNames.Contains(printerName))
            {
                throw new ArgumentException("Unknown printer name", "printerName");
            }
            // ...
        }
    }
