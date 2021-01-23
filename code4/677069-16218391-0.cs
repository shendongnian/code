    public class MyClass
    {
      private Dictionary<GUID, object> _myDictionary;
      public AddObject(object objectToAdd)
      {
          _myDictionary.Add(objectToAdd.GUID, objectToAdd);
      }
      public object GetObject(Type typeToGet)
      {
        return _myDictionary[typeToGet.GUID];
      }
    }
