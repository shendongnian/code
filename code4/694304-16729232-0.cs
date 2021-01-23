    class Wrapped<T> where T : new() {
       private T val = new T();
       ...
       public void Nullify() { val = null; }
    }
    
    private void SomeMethod()
    {
      var toBeNulledObj1 = new Wrapped<ABC>();
      var toBeNulledObj2 = new Wrapped<ABC>();
      var arrayOfNullableObjects = new Wrapped<ABC>[]{toBeNulledObj1 ,toBeNulledObj2};
      NullingFunction(arrayOfNullableObjects);
      Debug.Assert(toBeNulledObj1.Get() == null);
      // Or...
      Debug.Assert(toBeNulledObj1.IsDefined == false);
      // Or...
      Debug.Assert(toBeNulledObj1.IsNull == true);
    }
    
    private void NullingFunction(Wrapped<ABC>[] arrayOfNullableObjects)
    {
       for(int i = 0; i< arrayOfNullableObjects.Length ; i++)
         {
            arrayOfNullableObjects[i].Nullify();
         }
    }
