    [Serializable]
    public class A : ISerializable, IDeserializationCallback
    {
      List<B> listOfBs = new List<B>();
      public A()
      {
      // Create a bunch of B's and add them to listOfBs
      }
      public void OnDeserialization()
      {
        listOfBs.Remove(x=>x.s==5)
      }
    }
