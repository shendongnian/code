    public class MyType 
    {
        public static List<MyType> ClassInstance = new List<MyType>();
        public MyType() => ClassInstance.Add(this);
        public RemoveClass(MyType t)
        {
            ClassInstance.Remove(t);
            t = null;
        }
      
        public int ActiveCount => ClassInstance.Count;
    }
