    private void button1_Click(object sender, EventArgs e)
    {
        DateTime  sonsBirthday = DateTime.Parse(txtSonsBirthday.Text).Date;
        DateTime now =  DateTime.Now;
        TimeSpan timeSpan = now - sonsBirthday;
        //timeSpan = Convert.TimeSpan(lblTimeAlive); // old
        lblTimeAlive.Text = timeSpan.ToString(); // new
