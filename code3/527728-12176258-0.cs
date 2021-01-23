    var StartDate = new DateTime(2012,04,02);
    var EndDate = new DateTime(2012,08,28);
    var Name = "Test";
    if (!dataContext.TableAs.Any(
       x=> x.Name == Name && x.EndDate >= StartDate && x.StartDate <= EndDate
    )
    {
        //insert record
    }
