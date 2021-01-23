    class Book
     {
        public string bookTitle
        {
            get {return bookTitle; }
            set {bookTitle = value; }
        }
    
        ...
        
        public override string ToString() {
            return string.Format("{0}, {1}, {2}, {3}", 
                             authorFirstName, authorLastName, bookTitle, 
                             publicationYear);
        }
    }
