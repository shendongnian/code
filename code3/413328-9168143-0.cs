    class Book 
    { 
        public int ID { get; set; } 
        public string Title { get; set; } 
        public List<Genre> Genres { get; set; }
        public string Gen
        {
            get
            {
                return string.Join("; ", Genres.Select(g => g.Name));
            }
        }
    }
