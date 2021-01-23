    public void DoEachMember(MemberInfo[] members, object obj)
    {
       var properties = new List<dynamic>(); //dynamic objects list 
       properties.AddRange(members) ; // add all members to list of dynamics    
       foreach(dynamic d in porperties) //iterate over collection 
       {
          var attribs = d.GetCustomAttributes(typeof(MyAttribute), true); //call dynamicaly
          if (attribs.Length == 1)
          {
             // Get value of property.
             object value = d.GetValue(obj, null); //call dynamically
             DoAction(value);
          }
       }
     }
