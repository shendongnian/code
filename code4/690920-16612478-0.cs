    public class Program
    {
        static void Main(string[] args)
        {
            string a = "90000000000000000000000000000000000000000000000000000000000000000000000000001";
            string b = "100000000000000000000000000000000000000000000000000000000000000000000000000009";
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
                    if (char.GetNumericValue(first[i]) > char.GetNumericValue(second[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
