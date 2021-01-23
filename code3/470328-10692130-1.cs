    public static void ToLog(this Exception Exception)
    {
            using (var file = File.AppendText("ErrorLog.txt"))
            {
               file.WriteLine(DateTime.Now + " : " + exception.Message);
            }
    }
