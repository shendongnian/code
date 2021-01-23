    Class A
    {
      public event EventHandler EventA1
    
      public void MethodA1()
      {
        //some code
      }
      protected virtual void FireEventA1()
      {
        if (EventA1 != null)
          EventA1(new EventArgs());
      }
    
      protected virtual void ProcessWorkItem(workItem type)
      {
        switch (type)
        {
          case workItem.A1:
            ..
            break;
          case workItem.A2:
            ..
            break;
          case workItem.A3:
            ..
            break;
        }
      }
    }
    
    Class B : A
    {
      public event EventHandler EventB1
    
      public void MethodB1()
      {
        //some code
      }
      protected virtual void FireEventB1()
      {
        if (EventB1 != null)
          EventB1(new EventArgs());
      }
      protected override void ProcessWorkItem(workItem type)
      {
        base.ProcessWorkItem(type);
        switch (type)
        {
          case workItem.B1:
            ..
            break;
          case workItem.B2:
            ..
            break;
          case workItem.B3:
            ..
            break;
        }
      }
    }
