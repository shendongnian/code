    using (SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\projects\Chinook\Chinook40.sdf"))
    {
        using (Chinook db = new Chinook(conn))
        {
            var list = db.Album.ToList();
            if (list.Count > 0)
                System.Diagnostics.Debug.Print("It works!");
        }
    }
