    cvs.Filter += new FilterEventHandler(SomeFilterFunction1);
    cvs.Filter += new FilterEventHandler(SomeFilterFunction2);
    
    public void SomeFilterFunction1(object sender, FilterEventArgs e)
    {
          SomeObject example = e.Item as SomeObject;
          e.Accepted &= example.Name.Contains("A");
          //if you prefer OR logic use this one:          
          //e.Accepted |= example.Name.Contains("A");
    
    }
    
    public void SomeFilterFunction2(object sender, FilterEventArgs e)
    {
          SomeObject example = e.Item as SomeObject;
          e.Accepted &= example.Name.Contains("B");
          //if you prefer OR logic use this one:
          //e.Accepted |= example.Name.Contains("B");
    }
