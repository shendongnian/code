    using System.Collections.Generic;
    ...
    class Client
    {
       private Dictionary<string, yourObject> yourDict 
          = new Dictionary<string, yourObject>();
    
       public void Add (string id, yourObject value)
          { yourDict.Add (id, value); }
     
       public string this [string id]      // indexer
       {
       get { return yourDict[id]; }
       set { yourDict[id] = value; }
       }
    }
     
    public class Test
    {
       public static void Main( )
       {
          Client client = new Client();
          client.Add("A1",new yourObject() { Name = "Bla",...);
          Console.WriteLine ("Your result: " + client["A1"]); // indexer access
        }	
    }
