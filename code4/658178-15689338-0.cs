    void DoWork(object sender, DoWorkEventArgs e)
    {
        var data = new Datacollector();
        foreach (var i in data)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(_Data.Add(i)));
        }
    }
