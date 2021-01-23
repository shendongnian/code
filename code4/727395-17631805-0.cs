    public class Object
    {
        public string Color { get; set; }
        public int Weight { get; set; }
        public int Size { get; set; }
        private NodeState _state;
        public NodeState State { get { return _state; } set { _state = value; _state.Handle(); } }
    }
