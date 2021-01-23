    var price = from p in BooksDB.Price
                where p.Book_Name==bookName
                select p.Book_Price;
    //assuming Book_Price is stored as a string datatype.
    string bookPrice = price.FirstOrDefault();
    //otherwise
    string bookPrice = (price.FirstOrDefault() ?? "").ToString();
    
    if(!String.IsNullOrEmpty(bookPrice))
    {
        //do something with the string.
    }
