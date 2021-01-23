    int sum(int i, int j)
    {
     return i + j;
    }
    
    double sum(double i, double j)
    {
     return i + j;
    }
    
    object sum(object i, object j)
    {
      return i.ToString() + j.ToString();
    }
    
    ==============================
    
    static void Main()
    {
       sum(1, 2); // // calls int version, although are objects
       sum(1.0, 2.0); // double version, although are objects
       sum("Hello", "World"); // object
    }
