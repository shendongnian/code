    int timerTicks;
    int waitUntill = 10; //10 = 1 second. Change this to decide how long the application will wait.
    string mood;
    string word;
    string langConnection;
    DataTable tt;
    SqlCeConnection con;
    SqlCeDataAdapter b;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (!timer1.Enabled)
            timer1.Start();
        //Reset the timer when a character is entered in textBox1.
        timerTicks = 0;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        timerTicks++;
        if (timerTicks > waitUntill && !backgroundWorker1.IsBusy && comboBox1.SelectedItem != null)
        {
            //Stop the timer and begin the search in a background thread.
            timer1.Stop();
            word = textBox1.Text;
            mood = comboBox1.SelectedItem.ToString();
            backgroundWorker1.RunWorkerAsync();
        }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        tt = new DataTable();
        con = new SqlCeConnection(@"Data Source=" + Directory.GetCurrentDirectory() + @"\Database\condrokothadb.sdf;Password=000;");
        langConnection = String.Format("SELECT english,bangla FROM dic WHERE ({0} like '{1}%')", mood, word);
        using (con)
        {
            con.Open();
            b = new SqlCeDataAdapter(langConnection, con);
            b.Fill(tt);
        }
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        dataGridView1.DataSource = tt;
    }
