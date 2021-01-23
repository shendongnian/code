    string connecString = @"Data Source=D:\SQLite.db;Pooling=true;FailIfMissing=false";       
    /*D:\sqlite.db就是sqlite数据库所在的目录,它的名字你可以随便改的*/
    SQLiteConnection conn = new SQLiteConnection(connectString); //新建一个连接
    conn.Open();  //打开连接
    SQLiteCommand cmd = conn.CreateCommand();
    
    cmd.CommandText = "select * from orders";   //数据库中要事先有个orders表
    
    cmd.CommandType = CommandType.Text;
    using (SQLiteDataReader reader = cmd.ExecuteReader())
    {
       while (reader.Read())
                    Console.WriteLine( reader[0].ToString());
    }
