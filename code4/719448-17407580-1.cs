        string date = DateTime.Now.ToShortDateString();
        string time = DateTime.Now.ToShortTimeString();
        double pace = 16;
        double distance = 4;
        SQLiteConnection conn = new SQLiteConnection(System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Database.sqlite"));
        conn.Execute("Insert into HistoryTable values(?,?,?,?)", date, time, pace, distance);
