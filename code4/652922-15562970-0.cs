    using (SQLiteTransaction SQLiteTrans = connection.BeginTransaction())
                   {
                       using (SQLiteCommand cmd = connection.CreateCommand())
                       {
                         cmd.CommandText = ("update contents set content_1 ='" + paraNode + "' where content_id ='" + Count + "'");
                          
    
                           SQLiteParameter Field1 = cmd.CreateParameter();
                           SQLiteParameter Field2 = cmd.CreateParameter();
                           cmd.Parameters.Add(Field1);
                           cmd.Parameters.Add(Field2);
                           cmd.ExecuteNonQuery();
                       }
                       SQLiteTrans.Commit();
                   }
