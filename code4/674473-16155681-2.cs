    public int Position
    {
      get { return Session["Pointer"] as int? ?? position ?? 5 ; }
      set { position = value ; }
    }
    private int? position ; // backing store
