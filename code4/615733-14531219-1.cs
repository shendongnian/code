    public IndexRedirector Delta_Theta 
    { 
      get { return new IndexRedirector { RedirectedArray:delta_theta }; 
    }
    class IndexRedirector
    { 
      public double[] RedirectedArray;
      public double this[int index] {
        get { return RedirectedArray[index]; }
        set { RedirectedArray[index] = value; }
      }
    }
