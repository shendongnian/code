    Category {
        public string Id {get;set;}
        public List<string> CategoryIDs {get;set;}
        ...
    }
    var parent = session
        .Include(i => i.CategoryIDs)
        .Load<Category>("category/1");
    
    var children= session.Load<Category>(parent.CategoryIDs);
