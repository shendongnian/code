            public void Can_query_after_transaction_is_committed()
            {
                var connection = new OrmLiteConnectionFactory(":memory:", true, SqliteDialect.Provider, true);
                using (var db = connection.OpenDbConnection())
                {
                    db.DropAndCreateTable<SimpleObject>();
                    using (var trans = db.OpenTransaction()) 
                    {
                       db.Insert(new SimpleObject {test = "test"});
                       trans.Commit();
                    }
                    Assert.DoesNotThrow(()=> db.Select<SimpleObject>());
                }
            }
