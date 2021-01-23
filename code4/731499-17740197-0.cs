     public static void WriteToTextFile(string textLog)
     {
        FileStream objFS = null;
                
        string strFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Exception Log\" + System.DateTime.Now.ToString("yyyy-MM-dd ") + "Exception.log";
        if (!File.Exists(strFilePath))
        {
              objFS = new FileStream(strFilePath, FileMode.Create);
        }
        else
              objFS = new FileStream(strFilePath, FileMode.Append);
        using (StreamWriter Sr = new StreamWriter(objFS))
         {
             Sr.WriteLine(System.DateTime.Now.ToShortTimeString() + "---" + textLog);
          }
     }
