    MyChart.Series[0].DataSource = collection; //Populate Data 
    timer.Tick += new EventHandler(timer_Tick);
    timer.Interval = new TimeSpan(0, 0, 0, 0, 3000);// give some delay
    timer.Start();
            
    void timer_Tick1(object sender, EventArgs e)
    {
      ExportToImage(new Uri("d:/visifire1.png"), MyChart);
    }
