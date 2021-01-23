    int timerTicks;
    int waitUntill;
    public Form1()
    {
        InitializeComponent();
        timer1.Start();
        waitUntill = 10; 
        //10 = 1 second. Change this to decide how long the application will wait.
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (!timer1.Enabled)
            timer1.Start();
        timerTicks = 0;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        timerTicks++;
        if (timerTicks > waitUntill)
        {
            timer1.Stop();
            method(textbox1.Text);
        }
    }
    private void method(string word)
    {
        SqlCeConnection con = new SqlCeConnection(@"Data Source=" +
            Directory.GetCurrentDirectory() +
            @"\Database\condrokothadb.sdf;Password=000;");
        if (mood == "bangla") 
        {
            SqlCeDataAdapter b = new SqlCeDataAdapter("SELECT english,bangla FROM dic WHERE (bangla like '" + word + "%')", con);
            DataTable tt = new DataTable();
            b.Fill(tt);
            dataGridView1.DataSource = tt;
        }
        else
        {
            using (con)
            {
                con.Open();              
                using (SqlCeDataAdapter b = new SqlCeDataAdapter("SELECT english,bangla FROM dic WHERE (english like '" + word + "%')", con))
                {
                    DataTable tt = new DataTable();
                    b.Fill(tt);
                    dataGridView1.DataSource = tt;
                }
            }
        }    
    }
