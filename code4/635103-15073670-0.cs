    public void chkIfExist()
    {
        bool fireAgain = true;
        Dts.Events.FireInformation(0,
            "MyScriptTask",
            String.Format("srcPath is \"{0}\"", Dts.Variables["User::srcPath"].Value),
            "",
            0,
            ref fireAgain);
        Dts.Events.FireInformation(0,
            "MyScriptTask",
            String.Format("srcFile is \"{0}\"", Dts.Variables["User::srcFile"].Value),
            "",
            0,
            ref fireAgain);
        Dts.Events.FireInformation(0,
            "MyScriptTask",
            String.Format("srcFull is \"{0}\"", Dts.Variables["User::srcFull"].Value),
            "",
            0,
            ref fireAgain);
        string fullPath = Dts.Variables["User::srcFull"].Value.ToString();
        if (System.IO.File.Exists(fullPath))
        {
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        else
        {
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
    }
