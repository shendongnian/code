    public class Square
    {
        // Only Square and classes nested within it can call this
        private Square()
        {
        }
        public class Factory
        {
            public Square CreateSquare()
            {
                return new Square();
            }
        }
    }
