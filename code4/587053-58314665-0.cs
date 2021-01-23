                    using (AttendenceDataContext dboContext = new AttendenceDataContext())
                    {
                        var dQuery = dboContext.Database.SqlQuery<DateTime>("SELECT getdate()");
                        return dQuery.AsEnumerable().First();
                    }
