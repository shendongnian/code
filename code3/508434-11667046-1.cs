        public class GlobalSingletoneLocator
        {
          private static Dictionary<int,TabOnlyObject> _collection = new Dictionary<int, TabOnlyObject>();
         //Do all singleton initialization
         // ....
          public TabOnlyObject GetServiceByTabID(uint id)
          {
            //initialize and return the new instance of class you tried to use
            if(!_collection.ContainsKey(id))
            {
              var service = new TabOnlyObject();
              _collection.Add(id, service);
             }
            return _collection[id];
           }
    }
