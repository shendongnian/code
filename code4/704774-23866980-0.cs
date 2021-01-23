            private int DeleteData()
        {
            using (var ctx = new MyEntities(this.ConnectionString))
            {
                if (ctx != null)
                {
                    //Delete command
                    return ctx.ExecuteStoreCommand("DELETE FROM ALARM WHERE AlarmID > 100");
                   
                }
            }
            return 0;
        }
