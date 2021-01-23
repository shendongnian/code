    MyApplicationCode appCode;
    public Form1()
    {
        InitializeComponents();
        appCode = new MyApplicationCode();
        this.Text = appCode.GetFormText();
        label1.Text = appCode.GetLabelText();
        cmdSave.Enabled = appCode.UserHasSavePermission();
        ...... // and so on for other decisions on 
       
    }
