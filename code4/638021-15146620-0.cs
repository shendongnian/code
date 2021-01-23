    var query = Repository.GetQuery<Person>()
                          .Include(x => x.PersonDetail);
    if (String.IsNullOrWhiteSpace(ID))
    {
        query = query.Where(x => x.PersonDetail.ID2 == ID2);
    }
    else
    {
        query = query.Where(x => x.PersonDetail.ID == ID);
    }
    var result = query.SingleOrDefault();
