    public void Main()
    {
        string folder = Dts.Variables["User::folder"].Value.ToString();     //@"C:\temp\";
        string file = Dts.Variables["User::file"].Value.ToString();         //"a.txt";
        string fullPath = string.Format(@"{0}\{1}", folder, file);
        Dts.Variables["User::fileExists"].Value = File.Exists(fullPath);
        Dts.TaskResult = (int)ScriptResults.Success;
    }
