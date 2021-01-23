       public Search<T>(object o, string comparestring)
       {
             if(o is List<string>)
             {
             //Compare to your string
             }
             else
             {
                 //Call this search function with the type of the object in the list.
                 //Will iterate through all of your strings recursively.
                 Type t = o.GetType().GetGenericArguments()[0];
                 foreach( object osub in (T)o)
                     Search<t>( ((t)o),comparestring)
             }
        }
