     var books = from s in authors
                           where s.LastName == "Jones"
                           select s.Books;
    
        GridView2.DataSource = books.SelectMany(c => c).ToList();
        GridView2.DataBind();
