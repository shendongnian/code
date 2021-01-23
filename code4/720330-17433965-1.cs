    public enum FeaturesIndex
    {
        Favorite = 0,
        Nice = 1
    }
    public class Features2 : IEnumerable<string>
    {
        private static readonly string[] _features = new string[]
            {
                "blue background",
                "animation"
            };
        public string this [FeaturesIndex ix]
        {
            get { return _features[(int) ix]; }
        }
        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>) _features).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
