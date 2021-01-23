        SQLiteConnection conn = new SQLiteConnection(System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Database.sqlite"));
        var result = conn.Table<HistoryTable>();
        foreach (var val in result)
        {
            TimeSpan pace = TimeSpan.FromMinutes(val.pace);
            TextBoxDate.Text = val.date;
            TextBoxTime.Text = val.time;
            TextBoxPace.Text = pace.Minutes + ":" + pace.Seconds;
            TextBoxDistance.Text = val.distance + " Km";
        }
