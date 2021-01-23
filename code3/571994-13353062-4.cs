        class Program
        {
            public static void Main(string[] args) 
            {
                List<string> list = new List<string>(new string[]{"1234 1234 1234 1234", "1234123412341234","9999 9999 9999 9999"});
                SortedSet<string> set = new SortedSet<string>(list, new CreditCardNoComparer());
                foreach (string s in set)
                {
                    Console.WriteLine(s);
                }
                Console.ReadKey();
            }
        }
        public class CreditCardNoComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.Replace(" ", "").CompareTo(y.Replace(" ", ""));
            }
        }
