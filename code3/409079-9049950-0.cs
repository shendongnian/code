    class EasyProblemFactory
    {
        Problem Create()
        {
            return new Problem(...);
        }
        public int X;
        public int Y;
    }
    class MediumProblemFactory
    {
        Problem Create()
        {
            return new Problem(...);
        }
        public Bound<int> Range;
    }
    ...
