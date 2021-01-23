        public ICollection<ClassC> GetPageRange(int startingPage, int pagesPerPage)
        {
            return (from c in ClassCCollection
                    select c).Skip(startingPage).Take(pagesPerPage).ToList();
        }
