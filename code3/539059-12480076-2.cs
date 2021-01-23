    public void myFunc(BackgroundWorker bgw)
    {
        foreach (string Client in Clients)
        {
           // Do something
           // Return Client and insert into listview, richtextbox, W/E
           bgw.ReportProgress(0,someObjectRepresentingYourProgress)
        }
    } 
    void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker bgw = sender as BackgroundWorker;
        ControlsHelper.ControlInvike(listProcess, () => listProcess.Items.Add("Current").Name = "item1");
                myOtherClass cp = new myOtherClass();
                cp.myFunc(bgw);
    }
