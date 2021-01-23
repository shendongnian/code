    System.Windows.Threading.DispatcherTimer timer4;
    private void timer2_Tick(object sender, EventArgs e )
    {
        locationTextBox2.Text = "";
        if (locationTextBox2.Text == "")
        {
            Weatherframe.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("");
        }
        Weatherframe2.Source = Weatherframe.Source; 
        timer 4 = new System.Windows.Threading.DispatcherTimer();
        timer4.Interval = new TimeSpan(0, 0, 0, 4, 000); // 500 Milliseconds
        timer4.Tick += new EventHandler(timer4_Tick);
        timer4.Start();
    }
    void timer4_Tick(object sender, EventArgs e)
    {
        timer4.Stop();
        if (locationTextBox2.Text == String.Empty)
        {
            locationTextBox2.Text = textBlock2.Text;
        }
    }
