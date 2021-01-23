    IQueryable<Upload> query = db.Uploads;
    if (number != 666)
    {
       var niqquh = Languages[number];
       query = query.Where(w => w.Language == niqquh);
    }
    query = query
      .OrderBy(u => (u.Tags.Contains(word) ? 15 : 0) + (u.Name.Contains(word) ? 10 : 0) + (u.Description.Contains(word) ? 5 : 0))
      .Take(20);
    listOfList.Add(query.ToList()); 
