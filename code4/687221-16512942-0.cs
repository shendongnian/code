    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
       ** snip **    
        using (var db= new SQLite.SQLiteConnection(DBPath))
        {
            var query= db.Table<company>();
            lv.ItemsSource = query.ToList();
        }
    }
