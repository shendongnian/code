    private void ThisApplication_Startup(object sender, System.EventArgs e)
    {
        this.NewMail += new Microsoft.Office.Interop.
            Outlook.ApplicationEvents_11_NewMailEventHandler(
            ThisApplication_NewMail);
    }
    
    void ThisApplication_NewMail()
    {
    }
