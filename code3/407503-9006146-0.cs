    foreach (BookFormat bf in originalBook.BookFormats)
    {
        BookFormat format = m.db.BookFormat.FirstOrDefault(x => x.ID == bf.ID);
        if (format != null)
        {
             m.db.DeleteBookFormat(format);
        }
    }
    
    m.db.SaveChanges();
