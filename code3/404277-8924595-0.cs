    public class A
    {
      private List<int> myList;
      public A()
      {
        myList = new List<int>()
      }
    
      private void MethodeA()
      {
        lock(myList)
        {
          myList.Add(10);
        }
      }
    
      public void MethodeB()
      {
        CallToMethodInOtherClass(myList);
      }
    }
    
    public class OtherClass
    {
      public CallToMethodInOtherClass(List<int> list)
      {
       lock(list)
       {
         int i = list.Count;
       }
      }
    }
