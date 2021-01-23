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
       sum(1, 2); // Error: ambigous call between `int` and `double` versions
       sum(1.0, 2.0); // calls double version, although 1.0 and 2.0 are objects too
       sum("Hello", "World"); // object
    }
