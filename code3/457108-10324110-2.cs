    public void ProcessMonthlyLogFiles()
    {
        DateTime currentTime = DateTime.Now;
        int month = currentTime.Month - 1;
        int year = currentTime.Year;
        string path = Path.GetDirectoryName(Settings.DailyPath + year + @"\" + month + @"\");
        CalculateMonthlyStatistics(path);
    }
