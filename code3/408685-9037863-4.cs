    public class PicturesResource
    {
        XElement self;
        public PicturesResource()
        { self = XElement.Parse(Properties.Resources.Pictures); }
    
        public IEnumerable<Picture> Pictures
        { get { return self.GetEnumerable("picture", x => new Picture(x)); } }
    }
    
    public class Picture
    {
        XElement self;
        public Pictures(XElement self) { this.self = self; }
    
        public string Path { get { return self.Get("path", string.Empty); } }
        public string AppPath { get { return self.Get("apppath", string.Empty); } }
        
    }
