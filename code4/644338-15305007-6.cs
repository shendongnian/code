    public static BlogVM ToBlogVM(this Blog source)
    {
        return new BlogVM 
        {
             Title = source.Title.SubString(0, 10),
             Body = source.Body.SubString(0, 25),
             AuthorName = source.Author.Name,//assuming you have some kind of Author table, I'm sure you get the idea..
             Id = source.Id
        };
    }
