    public partial class Service : ServiceBase
    {
        List<string> printers = new List<string>();
        public Service()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            getPrinters();
        }
        private void getPrinters()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }
        
        }
        static void Main()
        {
            (new Service()).OnStart(null); // allows easy debugging of OnStart()
        }
