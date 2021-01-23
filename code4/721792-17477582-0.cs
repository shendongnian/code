    foreach (var newsitemz in GetAllItems)
    {
        if (newsitemz.Date <= DateTime.Now.AddDays(-2))
        {
            re.DeleteNews(newsitemz);   
        }
        re.save(); //assuming this is basically context.SaveChanges()
    }
