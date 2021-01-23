    #if PocketPC
    private static string _appPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    #else
    private static string _appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Application.CompanyName);
    #endif
    public const int KILOBYTE = 1024;
    public static string ErrorFile { get { return _appPath + @"\error.log"; } }
    public static void Log(string message)
    {
      if (String.IsNullOrEmpty(message)) return;
      using (FileStream stream = File.Open(ErrorFile, FileMode.Append, FileAccess.Write))
      {
        using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8, KILOBYTE))
        {
          sw.WriteLine(string.Format("{0:MM/dd/yyyy HH:mm:ss} - {1}", DateTime.Now, message));
        }
      }
    }
