    int a, b, c;
    public Constructor()
        : this(new ConstructorParameters())
    {
    }
    public Constructor(int x, int y)
        : this(new ConstructorParameters(x, y))
    {
    }
    public Constructor(int x, int y, int z)
    {
        a = x;
        b = y;
        c = z;
        //do stuff 
    } 
    private Constructor(ConstructorParameters parameters)
        : this(parameters.X, parameters.Y, parameters.Z)
    {
    }
    private class ConstructorParameters
    {
        public int X;
        public int Y;
        public int Z;
        public ConstructorParameters()
        {
            AnotherThing at = new AnotherThing(param1, param2, param3); 
            Something st = new Something(at, 10, 15) 
            SomethingElse ste = new SomethingElse("some string", "another string"); 
 
            X = st.CollectionOfStuff.Count; 
            Y = ste.GetValue(); 
            Z = (int)Math.Floor(533 / 39.384); 
        }
        public ConstructorParameters(int x, int y)
        {
            X = x;
            Y = y;
            Z = (int)Math.Floor(533 / 39.384);
        }
    }
