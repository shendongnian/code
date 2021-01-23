    public class MyClass 
    {
      public virtual void RemoveEntry(Entry entry) // or by index, name
      {
         // some checks over Entries collection
         entry.IsDeleted = true;
      }
    }
