    using System;
    using System.Collections;
    
    class Program
    {
      static void Main()
      {
          Hashtable hsTbl = new Hashtable();
    
          hsTbl.Add(1, "Suhas");
          hsTbl.Add(2, "Madhuri");
          hsTbl.Add(3, "Om"); 
          
          DictionaryEntry[] entries = new DictionaryEntry[hsTbl.Count];
          hsTbl.CopyTo(entries, 0);
          hsTbl.Clear();
    
          foreach(DictionaryEntry de in entries) hsTbl.Add(de.Value, de.Key);
    
          // check it worked
    
          foreach(DictionaryEntry de in hsTbl)
          {
             Console.WriteLine("{0} : {1}", de.Key, de.Value);
          }
      }
    }
