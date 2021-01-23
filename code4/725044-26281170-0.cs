    public void Main()
    {
        string fileName = Dts.Variables["User::sourcePath"].Value.ToString() + Dts.Variables["User::fileName"].Value.ToString();
        if (File.Exists(fileName))
        {
            Dts.TaskResult = (int)ScriptResults.Success;
        } 
        else 
        {
            Dts.Log(string.Format("File {0} was not found.",fileName),0,null);
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
    }
