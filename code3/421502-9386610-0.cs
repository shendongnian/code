    private void Form1_Load(object sender, EventArgs e)
    {
        DateTime LastCreatedDate = Properties.Settings.Default["LastDateTime"].ToDateTime();
        var filePaths = Directory.GetFiles(@"\\Pontos\completed\", "*_*.csv").Select(p => new {Path = p, Date = System.IO.File.GetLastWriteTime(p)})
            .OrderBy(x=>x.Date)
            .Where(x=>x.Date>=LastCreatedDate);
    }
