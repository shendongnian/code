    public class Square
    {
        private Square()
        {
        }
        public int Size { get; set; }
        public static class Factory
        {
            public static Square CreateClass()
            {
                return new Square { Size = 10 };
            }
        }
    }
