    [HttpPost]
    public ActionResult Save(PersonInputModel[] persons) 
    {
        foreach (var person in persons)
        {
            var name = person.Name;
            var age = person.Age;
            ...
        }
        ...
    }
