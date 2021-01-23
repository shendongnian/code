    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                string dataTableName = "SO.Files+File01DataTable";
                Type dataTableType = typeof(Files.File01DataTable).Assembly.GetType(dataTableName);
                Files.File01DataTable dt = (Files.File01DataTable)Activator.CreateInstance(dataTableType);
            }
        }
    }
