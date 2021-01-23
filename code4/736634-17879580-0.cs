    interface IRoomTarget
    {
        IBoxTarget this[string name] { get; }
    }
    interface IRoomSource
    {
        IBoxSource this[string name] { get; }
    }
    class Room : IRoomTarget, IRoomSource
    {
        Dictionary<string, Box> boxes = new Dictionary<string, Box>();
        public IBoxTarget IRoomTarget.this[string name]
        {
            get { return boxes[name]; }
        }
        IBoxSource IRoomSource.this[string name]
        {
            get { return boxes[name]; }
        }
    }
