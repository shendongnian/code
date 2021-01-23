        private void save_Click(object sender, EventArgs e)
        {
            using (var bookstoreContext = new yourContext())
            {
                var b = (BookClass)bds.Current;
                var book = bookstoreContext.Products.Single(c => c.BookId == b.BookId); //or .First()
                book.BookName = b.BookName;
                book.BookInfo = b.BookInfo;
                bookstoreContext.SubmitChanges();
            }
        }
