    List<List<string>> eList = new List<List<string>>();
    eList.Add(new List<string>() { "a", "b" }); <--
    eList.Add(new List<string>() { "a", "c" });
    eList.Add(new List<string>() { "b", "a" }); <--
    var megedList = eList.Select(x => new HashSet<string>(x))
                         .Distinct(new HashSetComparer()).ToList();
---
    public class HashSetComparer : IEqualityComparer<HashSet<string>>
    {
        public bool Equals(HashSet<string> x, HashSet<string> y)
        {
            return x.SetEquals(y);
        }
        public int GetHashCode(HashSet<string> obj)
        {
            return obj.Take(5).Aggregate(23, (sum, s) => sum ^= s.GetHashCode());
        }
    }
