    public class First()
    {
          private Second _second;
    
          public First()
          {
              _second = new Second(this);
              // Doing some other initialization stuff,
          }
    
          private class Second
          {
              public Second(First f)
              {
              }
          }
    }
