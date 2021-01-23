    //Constructor default to not loaded
    bool isLoaded = false;
    private string _name;
    public string Name 
    {
       get {
          if (!isLoaded)
             LoadData(); //this popultes not just but all the properties
          return _name;
       }
    }   
    private LoadData()
    {
        //Load Data
        isLoaded = true;
    }
 
