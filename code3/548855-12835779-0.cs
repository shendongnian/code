    var themes = session.Query<ForumTheme>().Select(t => new ThemeDto(t.Name)).List();
    
    var topMessages = new List<IEnumerable<string>>(themse.Count);
    
    foreach(var theme in themes)
    {
        var query = from message in session.Query<ForumMessage>()
                    from topic in message.Topics
                    from t in topic.Themes
                    where t.Name == theme.Name
                    orderby message.DatePosted desc
                    select message;
        topMessages.Add(query.Take(5).ToFuture());
    }
    
    for(int i = 0;i < topMessages.Count; i++)
    {
        themes.TopMessages = topMessages[i].ToList();
    }
    
    return themes;
