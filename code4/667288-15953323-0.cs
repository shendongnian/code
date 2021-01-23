     var db = new BookDBDataContext();
    
     var q = (from a in db.Books
              where a.Title.Contains(txtBookTitle));
    
     if(!String.IsNullOrEmpty(txtAuthor)) 
     {
          q = q.Where(a => a.Author.Contains(txtAuthor));
     }
    
     
     if(!String.IsNullOrEmpty(txtAuthor)) 
     {
          q = q.Where(a => a.Publisher.Contains(txtPublisher));
     }
     var id = q.Select(a => a.ID);
