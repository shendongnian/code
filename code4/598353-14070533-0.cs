    public class RandomList : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            Random r = new Random();
            
            while (true)
                yield return r.Next(1000, 9999);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
