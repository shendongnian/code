    public ActionResult Index(string bookName)
    {
       ViewData["BookName"] = new SelectList(_context.BookName.Select(a => a.Book_Name).Distinct());
       if (!string.IsNullOrWhiteSpace(bookName))
       {
           ViewData["Books"] = _context.BookName.Where(b => b.Book_Name == bookName).ToList();
       }
       return View();
    }
