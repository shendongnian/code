    new System.Threading.Thread(
    new System.Threading.ThreadStart(
    delegate()
    {
        MyService.MyServiceClient ms = new MyService.MyServiceClient();
        var v = ms.GetTotalCost();
        Action del = delegate()
        {
            lblTotalCost.Text = v.ToString("C");
        };
        this.Dispatcher.BeginInvoke(del);
    })).Start();
