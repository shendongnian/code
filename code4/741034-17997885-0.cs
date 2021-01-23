    if (File.Exists("inifile.ini"))
    {
       string[] allLines = File.ReadAllLines("inifile.ini");
       string deviceLine = allLines.Where(st => st.StartsWith("_DeviceName")).FirstOrDefault();
     
       if(!String.IsNullOrEmpty(deviceLine))
       {
          string value = deviceLine.Split('=')[1].Trim();
          MessageBox.Show(value);
       }
    }
