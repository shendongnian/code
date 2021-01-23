    protected void Button1_Click(object sender, EventArgs e) {
        Label1.Text = "Searching for services";
        //change postback hooks
        Button1.Click -= Button1_Click;
        Button1.Click += AnotherEventPB;
        ScriptManager.RegisterStarupScript(this, GetType(), postback, "__doPostBack();", true);
        UpdatePanel1.Update();
    }
    
    protected void AnotherEventPB(object sender, EventArgs e)
    {
            //reset postback hooks
            Button1.Click -= AnotherEventPB; 
            Button1.Click += Button1_Click;
            discovery.FindAlreadyRegisteredServices();
            discovery.discoveryClient.FindCompleted += FoundEvent;
            auto[1].WaitOne();
            UpdatePanel1.Update();
    }
