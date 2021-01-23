     public static class PhotoRepository 
        {
            private static BlogContext _ctx = new BlogContext();
    
            public static void Save(Photo p)
            {
                _ctx.Photos.Add(p);
                _ctx.SaveChanges();
            }
        }
