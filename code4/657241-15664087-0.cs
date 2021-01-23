    public static class LogHelper
    {
        public static void Log(String line)
        {
            var file = System.IO.Path.GetPathRoot(Environment.SystemDirectory)+ "Logs.txt";
            StreamWriter logfile = new StreamWriter(file, true);
            // Write to the file:
            logfile.WriteLine(DateTime.Now);
            logfile.WriteLine(line);
            logfile.WriteLine();
            // Close the stream:
            logfile.Close();
        }
    }
