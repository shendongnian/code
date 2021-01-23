        var blog = new BlogPost
        {
            Title = model.Title,
            Body = model.Body,
            Author = getAuthor(model.Id),
            CreatedDate = DateTime.Now,
            PublishDate = model.PublishDate ,
            Active = model.Active
        };
        //db.Entry(blog).State = EntityState.Modified; //just comment this line it worked for me
        db.SaveChanges();
