    public Tree root
    {
      get
      {
        if (parent == null) return this;
        else return parent.root; // now in tail position
      }
    }
