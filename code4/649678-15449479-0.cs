    public class Storage 
    {
       private Dictionary<Key, DomainObject> dict;
       public Storage()
       {
          dict = new Dictionary<Key, DomainObject>(Key.Comparer.Instance)
       }
       public DomainObject Get(uint a, uint b)
       {
          DomainObject obj;
          dict.TryGetValue(new Key(a,b), out obj);
          return obj;
       }
       internal struct Key 
       {
           internal readonly uint a;
           internal readonly uint b;
           public Key(uint a, uint b)
           {
              this.a = a;
              this.b = b;
           }     
    
           internal class Comparer : IEqualityComparer<Key>
           {
               internal static readonly Comparer Instance = new Comparer();
               private Comparer(){}
               public bool Equals(Key x, Key y)
               {  
                   return x.a == y.a && x.b == y.b;
               }  
               public int GetHashCode(Key x)
               {    
                  return (int)((x.a & 0xffff) << 16) | (x.b & 0xffff));
               }
           } 
       }  
    }
    
