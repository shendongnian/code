    public Object()
    {
        public Object Presentation { get; set; }
    }
    IQueryable list= (from u in db.Object select new Object { Presentation = u });
