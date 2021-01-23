    class MyClass
    {
        public MyClass(Coordinates coords)
        {
            this.coords = coords;
        }
        private Coordinates coords;
    }
    public struct Coordinates
    {
         public int X{get; set;}
         public int Y{get; set;}
         public int z{get; set;}
    }
