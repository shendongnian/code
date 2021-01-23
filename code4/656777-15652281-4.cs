    var set = new HashSet<List<Student>>(new CustomComparer());
    foreach (List<List<Student>> list in source)
    {
      if (set.Contains(list))
        continue;
      set.Add(list)
    }
    
    
    public class CustomComparer : IEqualityComparer<List<Student>>
    {
       public bool Equals(List<Student> one, List<Student> two)
       {
         if (one.Count != two.Count) return false;
         // simplest possible code to compare two lists
         // warning: runs in O(N*logN) for each compare
         return one.OrderBy(s=>s).SequenceEqual(two.OrderBy(s=>s));
       }
    
       public int GetHashCodeList<Student> item)
       {
         int ret = -1;
         foreach (var s in item)
           ret ^= s.GetHashCode();
         return ret;
       }
    }
