    static int count = 0;
    string s;
    private void SetClock_Click(object sender, EventArgs e)
    {
        count++;
        label5.Text = count.ToString("X2");
        DateTime time = DateTime.Now;
        s = "4D-" + "1A-" + "2B-" + "3C-" +(label5.Text);
        txtSend.Text = s; 
        // Set your s before assign or you can do without s like
        
        //txtSend.Text = "4D-" + "1A-" + "2B-" + "3C-" +(label5.Text);
    }
