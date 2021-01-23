    //The below code is just me pulling some data out of the air to work with
    var listOfIds = new List<int>();
    var data = new Dictionary<int, DateTime>();
    
    for (var i = 0; i < 5; i++)
    {
        if (i%2 == 0)
        {
            listOfIds.Add(i);
        }
    
        data.Add(i, DateTime.Now.AddDays(i));
    }
    
    //Now we have two ILists which match the type of data you were talking about, and you simply query them like so
    var datesWhereIdIsInList = (from id in listOfIds 
                                from date in data 
                                where id == date.Key 
                                select date.Value).ToList();
