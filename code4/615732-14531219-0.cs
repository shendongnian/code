    public IndexRedirector Delta_Theta 
    { 
      get { return new IndexRedirector { Array:delta_theta }; 
    }
    class IndexRedirector
    { 
      public double[] Array;
      public double this[int index] {
        get { return Array[index]; }
        set { Array[index] = value; }
      }
    }
