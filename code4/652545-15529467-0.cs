    class LayerClass
    {
      private Passenger p;
      private int ID;
      public Passenger P
      {
        get { return p; }
        set { p = value; }
      }
      public override string ToString() {
        if (p == null) {
          return "No Passenger";
        } else {
          return p.Name;
        }
      }
    }
