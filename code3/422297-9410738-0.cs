        mediaTitleCollection = new ArrayList();
        public BookMedia CreateBookTitle(string title, string subtitle, string edition, string author, string genre, int weight, int units, string isbn, int pages, int chapters)
        {
            BookMedia bm = new BookMedia(title, subtitle, edition, author, genre, weight, units, isbn, pages, chapters);
            mediaTitleCollection.Add(bm);
            // Return the object i have just added in mediaTitleCollection  
            return bm;
        }
