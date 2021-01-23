    public class MyBatchFile
    {
        public string Name { get; set; }
        public string FilePath { get; protected set; }
        public string DefaultParams { get; protected set; }
     
        public MyBatchFile(string filePath, string defaultParams)
        {
            FilePath = filePath;
            DefaultParams = defaultParams;
        }
   
        public string Run(string params = null)
        {
            System.Diagnostics.Process.Start(FilePath, (params ?? DefaultParams));
        }
    }
