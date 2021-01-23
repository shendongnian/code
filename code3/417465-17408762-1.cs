    private int x = 0;
    private int y = 100;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (x <= 100)
        {
            x++;
            string ping = new string(' ', x) + "COURT DOCUMENT MANAGEMENT SYSTEM";
            label1.Text = ping;
        }
        else if (y > 0)
        {
            y--;
            string pong = new string(' ', y) + "MY ARCHIVE MY LIFELINE!!!!"; // this is where the exceptions given
            label2.Text = pong;
        }
    }
