     int x;
     public void Bar()
     {
            x = 1; // NullRefException
            Debug.Assert(this == null);
     }
