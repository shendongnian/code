    List<List<object>> listOfCarObjects = new List<object>();
    listOfCarObjects.Add(new List<object>());
    LookAtCars(listOfCarObjects);
--------------------------------------------------------------------------------
    public void LookAtCars(List<objects> cars)
    {
       foreach(var item in cars)
       {
             List<object> innerList = item as List<object>
             foreach(innerItem in innerList)
             {
                 //do something with innerItem
             }
       }
    }
