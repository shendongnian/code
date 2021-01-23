    var data = db.Clients.Select(c => { c.Id, c.Firstname });
    foreach (var item in data)
    {
        var stringData = String.Format("{0}:{1}", item.Id, item.Firstname);
        ...
    }
