    Stopwatch sw = new Stopwatch();
    private void button1_Click(object sender, EventArgs e)
    {
        sw.Stop();
        TimeSpan x = sw.Elapsed;
        textBox1.Text = x.ToString();
        // >= .NET 4
        sw.Restart();    
        // >=.NET 2.0
        sw.Reset();
        sw.Start();                   
    }
