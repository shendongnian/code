    void timer4_Tick(object sender, EventArgs e)
    {
        if (locationTextBox2.Text == String.Empty)
        {
            locationTextBox2.Text = textBlock2.Text;
            System.Windows.Threading.DispatcherTimer theTimer = sender as System.Windows.Threading.DispatcherTimer;
            theTimer.Stop();
        }
    }
