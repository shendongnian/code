    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Author author = db.Authors.Find(id);
        // Count # of Books for this Author
        int count = (from book in db.Books
                            where book.BookId == id
                            select book.BookId).Count();
        // Prevent deletion of this record has any associated records
        if (count> 0)
        {
            TempData["errors"] = "Bad user! You can't delete this record yet!";
            return RedirectToAction("Delete");
        }
        else
        {
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
