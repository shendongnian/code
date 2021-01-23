    public class BoundingBox
    {
        public Vector3Double Positon { get; set; }
        public Vector3Double Apothem { get; set; }
        public IExtremasForX X { get { return _x; } }
        private ExtremasForX _x;
        public BoundingBox(Vector3Double position, Vector3Double size)
        {
            Positon = position;
            _x = new ExtremasForX(this);
        }
        public interface IExtremasForX {
            public double Max { get; }
            public double Min { get; }
        }
        
        private class ExtremasForX : IExtremasForX
        {
            private BoundingBox box;
            public ExtremasForX(BoundingBox box)
            {
                this.box = box;
            }
            public double Max
            {   
                get { return box.Positon.X + box.Apothem.X ; }
            }
            public double Min
            {
                get { return box.Positon.X - box.Apothem.X; }
            }
        }
    }
