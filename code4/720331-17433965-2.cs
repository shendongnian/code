    public class Features: IEnumerable<string>
    {
        public const string Favorite = "blue background";
        public const string Nice = "animation";
        public IEnumerator<string> GetEnumerator()
        {
            yield return Favorite;
            yield return Nice;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
