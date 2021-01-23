    var price = from p in BooksDB.Price
                where p.Book_Name==bookName
                select p.Book_Price;
    string bookPrice = price.FirstOrDefault();
    
    if(!String.IsNullOrEmpty(bookPrice))
    {
        //do something with the string.
    }
