    void Button_Click()
    {
      int i = 0;
      var t = new DispatcherTimer();
      t.Interval = TimeSpan.FromSeconds(1);
      t.Tick += (s, e) => { textbox.Text = i.ToString; i++; if (i == 20) t.Stop(); };
      t.Start();
    }
