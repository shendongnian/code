    public class MyClass{
      ...
      public virtual ICollection<Entry> Entries {get;set;}
    
      public void DeleteEntry(Entry entry)
      {
          entry.IsDelete = true;   
      }
    }
