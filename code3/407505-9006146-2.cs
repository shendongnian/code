    List<int> idsToDelete = new List<int>();
    foreach (BookFormat bf in originalBook.BookFormats)
    {
        idsToDelete.Add(bf.ID);
    }
    foreach (int id in idsToDelete)
    {
        BookFormat format = m.db.BookFormat.FirstOrDefault(x => x.ID == id);
        if (format != null)
        {
             m.db.DeleteBookFormat(format);
        }
    }
    
    m.db.SaveChanges();
