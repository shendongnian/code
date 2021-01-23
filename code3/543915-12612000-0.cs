    void MyButton_Click(object sender, EventArgs e)
    {
        var backgroundThread = new Thread(DoWork);
        this.MyBusyIndicator.IsBusy = true;
        backgroundThread.Start();
    }
