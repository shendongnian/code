    void EnsureData()
    {
          if (!dataLoaded) 
             LoadData(); //this populates all the properties 
    }
    
    public string Name {
       get { 
          EnsureData();
          return _name; 
       } 
    }
