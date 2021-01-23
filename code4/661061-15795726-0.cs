    public partial class Service : ServiceBase
        {
        public Service()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
          foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
          {
            string printerName = printer;
          }
        }
        protected override void OnStop()
        {
        }
        static void Main()
        {
            (new Service()).OnStart(null); // allows easy debugging of OnStart()
        }
    }
