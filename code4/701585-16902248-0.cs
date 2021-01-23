    public void GetData()
    {
      while(true)
     {
          Foo foo = bar.GetData();
    
          if(foo == null)
          {
              bar.addItem("Test");
          }
          else break;
     }
    }
