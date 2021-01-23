    //for when the user's data is split in 2 fields
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //for when the user's data is all in one field
    public string FirstLastName { get; set; }
    public string FullName
    {
       get { ... }  // pick from LastName, FirstName, FirstLastName 
    }
    public string SortName
    {
       get { ... }  // pick from LastName, FirstLastName 
    }
