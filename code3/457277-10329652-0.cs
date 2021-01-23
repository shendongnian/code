    Public class CustomClass
    {
        public string HTML { get; set; }
        public bool Load  { get; set; }
    }
    
    [WebMethod()]
    public static StatusViewModel  GetDataFromServer()
    {
        // do work
        return CustomObject;
    }
