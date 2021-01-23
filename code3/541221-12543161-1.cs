    public class MyEqualityComparer : IEqualityComparer<string[]>
    {
        public int GetHashCode(string[]item)
        {
             int hashcode = 0;
             foreach (string s in item)
             { 
                 hashcode |= s.GetHashCode();
             }
             return hashcode;
        }
        public bool Equals(string [] a, string [] b)
        {
             if (a.Length != b.Length)
                 return false;
             for (int i = 0; i < a.Length; ++i)
             {
                 if (a[i] != b[i])
                     return false;
             }
             return true;
       }
