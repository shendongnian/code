    // Keep a field of type System.Windows.Forms.Timer
    timer = new Timer();
    timer.Interval = 1000;
    timer.Tick += DisplayTicker;
    timer.Start();
    ...
    private async void DisplayTicker(object sender, EventArgs e)
    {
        Ticker ticker = await BtceApiAsync.GetTickerAsync(BtcePair.LtcUsd);
        label1.Text = "LTC/USD: " + ltcusd.Last;
    }
