    using (var entity = new MyModel(ConnectionString))
                {
                    var query = (from myTable in entity.theTable
                                where myTable.FacilityID == facilityID &&
                                   myTable.FilePath != null &&
                                   myTable.TimeStationOffHook < oldDate
                                orderby myTable.FilePath
                                select new
                                {
                                    myTable,FileName,
                                    myTable.FilePath
                                 }).Skip(1000).Take(1000).ToList();
    //do what you want with the query result here
                }
