    List<List<string>> eList = new List<List<string>>();
    eList.Add(new List<string>() { "a", "b" });
    eList.Add(new List<string>() { "a", "c" });
    eList.Add(new List<string>() { "a", "b" });
    var mergedList = eList.Distinct(new ListComparer()).ToList();
 
---
    public class ListComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<string> obj)
        {
            return obj.Take(5).Aggregate(23,(sum,s)=> sum ^= s.GetHashCode());
        }
    }
