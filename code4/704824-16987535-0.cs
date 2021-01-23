    public static class Logger
    {
        public static List<Error> Logs = new List<Error>();
        public static void Log(Exception ex,string fileName)
        {
            Logs.Add(new Error
            {
                Message = ex.Message,
                FileName = fileName
            });
            //Here you can log errors to database,txt or xml too.
        }
    }
    public class Error
    {
        public string Message { get; set; }
        public string FileName { get; set; }
    }
