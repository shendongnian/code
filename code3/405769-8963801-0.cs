    class Ball
    {
        public string Name { get; private set; }
        public int Size { get; private set; }
        public Ball(string name, int size) 
        { 
            this.Name = name;
            this.Size = size;
        }
        public Ball(Ball first, Ball second)
            : this(first.Name + "," + second.Name, first.Size + second.Size)
        { }
    } 
