    public Task<T> GetData<T>(T dataObject) where T : MyKnownBaseObject
    {
        var typeName = typeof(T).Name;    
        switch (typeName)
        {
            case "PersonalInfo":
                var person =  new PersonalInfo
                         {
                         FirstName = "Mickey",
                         LastName = "Mouse" ,
                         Adres = new Address{Country="DLRP"} ,
                    };
                return Task.FromResult<T>(person);
                break;
            default:
                   return Task.FromResult<T>(default(T));
    
        }   // end Switch
    
    }   // GetData<T>
