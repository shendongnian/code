    public class Program
    {
        static void Main(string[] args)
        {
            string a = "0000000090000000000000000000000000000000000000000000000000000000000000000000000000001";
            string b = "000100000000000000000000000000000000000000000000000000000000000000000000000000009";
            Console.WriteLine(FirstIsBigger(a, b));
            Console.ReadLine();
        }
        static bool FirstIsBigger(string first, string second)
        {
            first = first.TrimStart('0');
            second = second.TrimStart('0');
            if (first.Length > second.Length)
            {
                return true;
            }
            else if (second.Length == first.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    double x = char.GetNumericValue(first[i]);
                    double y = char.GetNumericValue(second[i]);
                    if (x > y) return true;
                    else if (x == y) continue;
                    else return false;
                }
            }
            return false;
        }
    }
