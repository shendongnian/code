     public void TestAttribute()
        {
            MailJobView view = new MailJobView();
            string displayname = view.Attributes<DisplayNameAttribute>("Name") ;
        }
