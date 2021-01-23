    void timer4_Tick(object sender, EventArgs e)
    {
        if (locationTextBox2.Text == String.Empty)
        {
            locationTextBox2.Text = textBlock2.Text;
            Timer theTimer = sender as Timer;
            theTimer.Stop();
        }
    }
