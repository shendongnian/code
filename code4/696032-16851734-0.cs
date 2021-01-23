    var GetAllItems = re.GetAllWorldNewsByID();
    foreach (var newsitemz in GetAllItems)
    {
        if (newsitemz.Date <= DateTime.Now.AddDays(-1))
        {
            re.DeleteNews(newsitemz);
            re.save();
        }
    }
