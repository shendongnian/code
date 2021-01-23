    public string Salutation { get; set; }
    public string Name { get; set; }
    public string Greeting 
    { 
      get { return string.Format("{0}, {1}!", Salutation, Name); } 
    }
