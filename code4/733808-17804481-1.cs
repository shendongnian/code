    class Program
    {
        static void Main(string[] args)
        {
            List<byte> b = new List<byte>() { 50, 60, 70, 80, 90, 10, 20, 1, 2, 3, 4, 5, 50, 2, 3, 1, 2, 3, 4, 5 };
            List<byte> b2 = new List<byte>() { 1, 2, 3, 4, 5 };
            SmartComparer comparer = new SmartComparer();
            var result = comparer.CompareArraysWithDepth(b, b2, 3);
            foreach (var keyValuePair in result)
            {
                Console.WriteLine(String.Format("b[{0}]->b[{1}] are equal to b2[{2}]->b2[{3}]", keyValuePair.Key.Key,
                                                keyValuePair.Key.Value, keyValuePair.Value.Key, keyValuePair.Value.Value));
            }
        }
    }
    public class SmartComparer
    {
        public Boolean CompareRange(List<byte> a, List<byte> b)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
        public List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> CompareArraysWithDepth(
            List<byte> a, List<byte> b, int depth)
        {
            var result = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();
            if (depth > b.Count)
                throw new ArgumentException("Array 'b' item count should be more then depth");
            if(a.Count<b.Count)
                throw new ArgumentException("Array 'a' item count should be more then Array 'b' item count");
            for (int i = 0; i <= a.Count - depth; i++)
            {
                for (int j = 0; j <= b.Count - depth; j++)
                {
                    if (CompareRange(a.GetRange(i, depth), b.GetRange(j, depth)))
                    {
                        result.Add(new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(new KeyValuePair<int, int>(i, i + depth-1), new KeyValuePair<int, int>(j, j + depth-1)));
                    }
                }
            }
            return result;
        }
    }
