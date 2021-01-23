    var properties = this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    
    foreach (var p in properties)
    {
    	string propertyName = p.Name;
    }
