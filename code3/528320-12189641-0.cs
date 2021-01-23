    class Program
    {
        internal static ILog logger = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            string firstName, lastName, dob, lexisNexisID;
            string filePath = @"yor directory path\your file name";
            
            ExcelProvider provider = ExcelProvider.Create(filePath, "Sheet1");
            foreach (ExcelRow row in (from x in provider select x))
            {
                Console.WriteLine("{0}", row.GetString(1));
