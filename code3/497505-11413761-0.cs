        private static SomeObject _books;
        protected static SomeObject Books
        {
            get
            {
                if (_books == null) {
                    _books = new SomeObject();
                }
                return _books ;
            }
        }
        protected static SomeObject AVariable
        {
            get
            {
                SomeObject books = HttpContext.Current.Items["books"] as SomeObject; 
                if (books == null) {
                    books = new SomeObject();
                    HttpContext.Current.Items["books"] = books;
                }
                return books;
            }
        }
