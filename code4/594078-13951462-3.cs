    public Tree root
    {
      get
      {
        Tree temp = this;
        while (true)
        {
          if (temp.parent == null)
          {
             return temp;
          }
          temp = temp.parent;
        }
      }
    }
