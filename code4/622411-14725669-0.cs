    @{
        string itemsToShow = "namepart"; // this could also be "otherpart"
        var list = new List<Expression<Func<MyViewModel, object>>>();
        if (itemsToShow == "namepart")
        {
            list.Add(x => x.FirstName);
            list.Add(x => x.SecondName);
        }
        else 
        {
            list.Add(x => x.DateOfBirth);
            list.Add(x => x.DateOfWorkStart);
            list.Add(x => x.NumberOfChildren);
        }
    }
