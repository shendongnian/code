    public static  class Program
        {
            public static void Main()
            {
                ExtractResource();
            }
    
            public static void ExtractResource()
            {
                //replace your embedded file by yours 
                using (var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication1.XMLFile1.xml"))
                {
                    using(var outputStream = File.Create(@"D:\test.bat"))
                    {
                        /// fix your buffer size 8192,4096 etc.
                        var buffer = new byte[8192];
    
                        int numberOfBytesRead;
                        while (inputStream != null && (numberOfBytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputStream.Write(buffer, 0, numberOfBytesread);
                        }
                    }
                }
        
            }
