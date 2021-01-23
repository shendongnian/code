    //here you can even load only the needed info if you don't need the whole entity.
    //I imagine you might only need the name and the Pages.Count which you can use below, this would be another optimization.
    var allAuthors = db.Authors.All(); 
    var totalPageCount = allAuthors.Sum(x => x.Pages.Count);
    var theEndResult = allAuthors .Select(a => new
             {
               Author = a,
               Popularity = a.Pages.Count/ (double)totalPageCount
             });
    
