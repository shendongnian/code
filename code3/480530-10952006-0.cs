     List<string> words = Search.GetTags(q);
     using(ShapesDataContext context = new ShapesDataContext())
     {
       IQueryable<Shape> query = Enumerable.Empty<Shape>().AsQueryable();
       foreach (var word in words)
       {
         query = query.Union(context.Shapes.Where(x => x.Title.Contains(word) || x.Description.Contains(word)));
       }
