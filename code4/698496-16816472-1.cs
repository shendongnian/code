    //the example data provided by the OP
    var data = new []
    {
        new { Record = 1, Id = "A", State = "Waiting", Date = new DateTime(2013, 1, 1) },
        new { Record = 2, Id = "A", State = "InProgress", Date = new DateTime(2013, 1, 2) },
        new { Record = 3, Id = "A", State = "Finished", Date = new DateTime(2013, 1, 3) },
        
        new { Record = 4, Id = "B", State = "Waiting", Date = new DateTime(2013, 1, 1) },
        
        new { Record = 5, Id = "C", State = "Waiting", Date = new DateTime(2013, 1, 1) },
        new { Record = 6, Id = "C", State = "InProgress", Date = new DateTime(2013, 1, 2) },
        
        new { Record = 7, Id = "D", State = "Waiting", Date = new DateTime(2013, 1, 1) },
        new { Record = 8, Id = "D", State = "InProgress", Date = new DateTime(2013, 1, 2) },
    };
    
    var query = from d in data
                //put the newest record first
                orderby d.Date descending
                //group by the id
                group d by d.Id into groupedById
                //get the latest record for each id
                let latest = groupedById.First()
                //filter out finished records
                where latest.State != "Finished"
                select latest;
