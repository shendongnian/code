        public List<Book> SearchForBooks(string phrase)
        {
            return _db.Books.Include(x=> x.Images).LikeOr("Title", phrase).OrderBy(x => x.Title)
                .Take(6).Select(x => x).ToList()
                .OrderByCountDescending("Title", phrase);
        }
