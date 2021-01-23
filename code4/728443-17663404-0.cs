    public class BoundingBox
    {
        public Vector3Double Positon { get; set; }
        public Vector3Double Apothem { get; set; }
        public ExtremasForX X;
        public BoundingBox(Vector3Double position, Vector3Double size)
        {
            Positon = position;
            X = new ExtremasForX(this);
        }
        private class ExtremasForX
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
