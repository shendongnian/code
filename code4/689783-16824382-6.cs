    var selector = new Selector<Person>();
    selector.Add(m => m.Address).Add(m => m.Place);
    selector.Add(m => m.Address).Add(m => m.ParentName).Add(m => m.Id); //at this stage discard duplicates
    selector.Add(m => m.Address).Add(m => m.ParentName).Add(m => m.FirstName); //and so on
    selector.Add(m => m.Name)... etc
    selector.Add(m => m.Age);
