    public Task<T> GetData<T>(T dataObject)
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
    
        }   // end Switch
    
    }   // GetData<T>
