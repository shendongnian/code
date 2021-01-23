    while (true)
    {
        if (AppSettings.SomeFormSettng = FormSetting.ShowAnotherForm)
        {
            Form showThisForm = AppSettngs.TheForm;
            if (ThisIsTheFirstRun)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ThisIsTheFirstRun = false;
            }
            Application.Run(new showThisForm ());
        }
        else
        {
            return;
        }
    }
