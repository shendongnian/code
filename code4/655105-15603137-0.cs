    public class Storage
    {
       private HashSet<Key> set;
       public Storage()
       {
          set = new HashSet<Key>(new Key.Comparer());
       }
       public void Add(string a, string b)
       {
          set.Add(new Key{A=a, B=b});
       }
       public bool Contains(string a, string b)
       {
          return set.Contains(new Key{A=a, B=b});
       }
       internal class Key
       {
           internal String A { get; set; }
           internal String B { get; set; }
           internal class Comparer : IEqualityComparer<Key>
           {
              public bool Equals(Key x, Key y)
              {
                 return (x.A == y.A && x.B == y.B) || (x.A == y.B && x.B == y.A);
              }
              public int GetHashCode(Key k)
              {
                 int aHash = k.A.GetHashCode();
                 int bHash = k.B.GetHashCode();
                 // Hash for (x,y) same as hash for (y,x)
                 if (aHash > bHash)
                    return bHash * 37 + aHash;
                 return aHash * 37 + bHash;
              }
           }
       }
    }
