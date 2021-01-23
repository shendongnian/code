    IssuedBooks = (from transaction in db.BookTransaction
    join tag in db.BookTagMaster on transaction.BookTagID equals tag.ID
    where tag.IsTagActive == true
    join book in db.BookMaster on tag.BookID equals book.ID
    join author in db.AuthorMaster on book.AuthorID equals author.ID
    join category in db.CategoryMaster on book.CategoryID equals category.ID
    join publisher in db.PublisherMaster on book.PublisherID equals publisher.ID
    select new BookIssuedView
    {
        ID = transaction.ID,
        EmployeeName = transaction.EmployeeName,
        IssuedDate = transaction.IssuedDate,
        ReturnDate = transaction.ReturnDate,
        BookName = book.Name,
        AuthorName = author.Name,
        CategoryName = category.Name,
        PublisherName = publisher.Name,
        SiteID = tag.SiteID,
        BuildingID = tag.BuildingID,
        LateFees = transaction.LateFees,
        DueDate = transaction.DueDate,
        LateBy = (!transaction.IsReturned && !transaction.ReturnDate.HasValue)?0:(transaction.ReturnDate.Value - transaction.DueDate).TotalDays   
    }).ToList();       
