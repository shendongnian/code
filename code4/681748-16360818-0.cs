    // Client-side
    interface IBox
    {
        IEnumerable<ITool> Tools { get; }
    }
    interface ITool
    {
        void Use();
    }
    // Server-side
    class Box : IBox
    {
        public List<Tool> ToolList = new List<Tool>();
        public IEnumerable<ITool> Tools
        {
            get { return ToolList; }
        }
    }
    class Tool : ITool
    {
        string _msg = "default msg";
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        public void Use()
        {
            Console.WriteLine("Tool used! Msg: {0}", _msg);
        }
    }
    interface IRoom
    {
        IEnumerable<IBox> Boxes { get; }
    }
    class Room : IRoom
    {
        public List<Box> BoxList = new List<Box>();
        public IEnumerable<IBox> Boxes
        {
            get { return BoxList; }
        }
    }
