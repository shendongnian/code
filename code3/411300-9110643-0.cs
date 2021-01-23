    public string GetMyObjectInJson(parameters)
    {
        MyObject object = GetMyObject();
        Javascript Serializer = new JavascriptSerializer();
        return Serializer.serialize(TheObject); 
    }
    
    public MyObject GetMyObject(parameters)
    {
         MyObject TheObject = new MyObject(); 
         ...lots of work here
         return TheObject; 
    }
