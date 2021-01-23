    [HttpPost]
    public ActionResult DeleteBook(int bookId)
    {
       bookRepository.DeleteBook(bookId);
       return RedirectToAction("Books", "ProductManager");
    }
