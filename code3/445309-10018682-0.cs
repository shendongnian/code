    var properties = new List<dynamic>(); //dynamic objects list 
    properties.AddRange(members) ; // add all members to list of dynamics    
    foreach(dynamic d in porperties)
    {
       var attribs = d.GetCustomAttributes(typeof(MyAttribute), true);
       if (attribs.Length == 1)
       {
          // Get value of property.
          object value = d.GetValue(obj, null);
          DoAction(value);
        }
    }
