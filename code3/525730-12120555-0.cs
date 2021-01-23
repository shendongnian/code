    private int order;
    public int Order
    {
       get
       {
          return order; //private field
       }
       set
       {
          if ((value < 0) || (value > 99)) {
                   throw new Exception(string.Format("{0} must be between 0 and 99",    
                                         value.ToString()));
          } else {
              order = value; // again accessing the private field (setting this time)
          }
       }
    }
