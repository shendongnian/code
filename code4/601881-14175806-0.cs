    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int Rating { get; set; }
        public Statistics Stats { get; set; }
       
      public string displayRating 
        {
            get
            {
                if (Rating > 0)
                {
                    var temp = "";
                    for (int i = 0; i < Rating; i++)
                    {
                        temp += "*";
                    }
                    return temp;
                }
                return "No rating found";
            } 
        }
    }
