    public class Simulation : IEnumerable<string>
    {
        private IEnumerable<string> Events()
        {
            yield return "a";
            yield return "b";
        }
    
        public IEnumerator<string> GetEnumerator()
        {
            return Events().GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
