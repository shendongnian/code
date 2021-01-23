            List<string> mItems = new List<string>();
            var listview = FindViewById<ListView>(Resource.Id.listview);
     //fetching data from database. I am using sqlite.cs to fetch data from database.
     //You can use your technique which you are using.
            using (var conn = new SQLite.SQLiteConnection(dbPath))
            {
                try
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "select * from history";
                    int i = 0;
                    var r = cmd.ExecuteQuery<hist>();
                    foreach (var item in r)
                    {
                        mItems.Add(item.word);
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
            
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            listview.Adapter = adapter;
