     public class PhotoRepository : IDisposable
        {
            private BlogContext _ctx = new BlogContext();
    
            public void Save(Photo p)
            {
                _ctx.Photos.Add(p);
                _ctx.SaveChanges();
            }
            void IDisposable.Dispose() { _ctx.Dispose(); }
        }
