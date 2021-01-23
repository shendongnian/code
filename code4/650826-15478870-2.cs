    var filter = Lambda.Expression(Person p => p.Name.Contains(some_criterion));
    if (userWantsStartsWith)
    {
        filter = Lambda.Expression(Person p => p.Name.Contains(some_criterion));
    }
    
    var query = from p in container.people.AsExpandable()
                where filter.Invoke(p)
                select p;
