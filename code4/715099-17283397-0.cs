    public interface IDenemeInterface
    {
        string convertToLower();
    }
    public class Deneme : IDenemeInterface
    {
        private string s;
        public Deneme(string s)
        {
            this.s = s;
        }
        public string convertToLower()
        {
            return this.s.ToLower();
        }
    }
