    bool allExist = !firstArray.Except(secondArray, new MyComparer()).Any()
---
    public class MyComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.StartsWith(y);
        }
        public int GetHashCode(string obj)
        {
            return obj[0].GetHashCode();
        }
    }
