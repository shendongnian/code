    public class PicturesCollection
    {
        public event EventHandler<PictureAddedEventArgs> PictureAdded;
        private List<string> _pictures = new List<string>();
    
        public void Add(string name)
        {
            _pictures.Add(name);
            if (PictureAdded != null)
                PictureAdded(this, new PictureAddedEventArgs(name));
        }
    
        public IEnumerable<string> Pictures
        {
            get { return _pictures; }
        }
    }
