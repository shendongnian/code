    public class Album
    {
        private List<Photo> _photos = new List<Photo>();
        public IEnumerable<Photo> Photos { get { return _photos; } }
        
        public void AddPhoto(Photo photo)
        {
            _photos.Add(photo);
        }
    }
