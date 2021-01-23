    public interface DenemeInterface
    {
        string convertToLower();
    }
    public class Deneme : DenemeInterface
    {
        string a;
        public Deneme(string s)
        {
            this.a = s;
        }
        public string convertToLower()
        {
            return a.ToLower();
        }
    }
