    public IList<string> GetBookTitles()
        {
            IList<string> tmp = new List<string>();
            // do something to populate the bookTitles list.
            IList<string> bookTitles = new ReadOnlyCollection<string>(tmp);
            return bookTitles;
        }
