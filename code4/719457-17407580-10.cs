        string date = string.Format("{0:00}.{1:00}.{2:00}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        string time = DateTime.Now.ToString("HH:mm:ss");
        double pace = 16.5;
        double distance = 4;
        SQLiteConnection conn = new SQLiteConnection(System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Database.sqlite"));
        conn.Execute("Insert into HistoryTable values(?,?,?,?)", date, time, pace, distance);
