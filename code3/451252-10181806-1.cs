    public class PictureAddedEventArgs : EventArgs
    {
        public PictureAddedEventArgs(string name)
        {
            Name = name;
        }
    
        public string Name { get; private set; }
    }
