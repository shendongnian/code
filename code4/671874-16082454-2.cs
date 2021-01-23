    var disjunction = new Disjunction();
    var query = Session.QueryOver<Log>().Where(l => l.DateTime > _datetime);
    foreach (var name in _names)
    {
        disjunction.Add(Restrictions.On<Log>(log => log.Name).IsLike(name));
    }
    var queryResult = query.Where(disjunction).List<Log>();
