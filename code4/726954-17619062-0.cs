    using (var context = new DbEntities()) {
        foreach (var p in context.Parents) {
            var childQuery = from c in p.Children 
                             where c.whatever == something 
                             select c;
            // Do something with the items in childQuery, like add them to a List<Child>,
            // or maybe a Dictionary<Parent,List<Child>>
        }
    }
