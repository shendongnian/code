    @model IEnumerable<MvcApplication1.Models.Book>
    @{
        ViewBag.Title = "Books";
     }
    <h2>Books</h2>
    @foreach(var book in Model)
    {
       @Templates.Print(book.Title,book.ISBN);    
    }
