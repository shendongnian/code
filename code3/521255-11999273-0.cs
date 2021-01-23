    public enum Letters
        {
            A = 1,
            B = 2,
            ...
        }
    public void someFunction(int value)
        {
          switch(value)
            {
               case (int)Letters.A: {/* Code */ break;}
               case (int)Letters.B: {/* Code */ break;}
               ...
            }
        }
