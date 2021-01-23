    public void MyMethod(params string[] properties) 
    {
        var pairs = new Dictionary<string, string>();
    
        for(int i = 0; i < properties.length - 1; i += 2) 
        {
            pairs[properties[i]] = properties[i + 1];
        }
    }
    
    MyMethod("Name", "Jack", "City", "New York", "Gender", "Male");
