    class Y             
    {
       private object _x;
       public object x {
           get { return _x; }
           set
           {
               if (value.GetType != typeof(X) && value.GetType != typeof(X[]))
                   throw new ArgumentException("value");
               _x = value;
           }
       }
    }
