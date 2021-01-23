            public void Can_query_after_transaction_is_committed()
            {
                var connection = new OrmLiteConnectionFactory(":memory:", true, SqliteDialect.Provider, true);
                using (var db = connection.OpenDbConnection())
                {
                    db.DropAndCreateTable<SimpleObject>();
                    var trans = db.OpenTransaction();
                    db.Insert(new SimpleObject {test = "test"});
                    trans.Commit();
                    trans.Dispose();
                    Assert.DoesNotThrow(()=> db.Select<SimpleObject>());
                }
            }
