        static class Program
    {
        static void Main()
        {
            Console.WriteLine("2X + 65Y + z^3".GetNumbersFromString().Sum());
            Console.ReadLine();
        }
        static IEnumerable<int> GetNumbersFromString(this string input)
        {
            StringBuilder number = new StringBuilder();
            foreach (char ch in input)
            {
                if (char.IsDigit(ch))
                {
                    number.Append(ch);
                }
                else if (number.Length > 0)
                {
                    yield return int.Parse(number.ToString());
                    number.Clear();
                }
            }
            yield return int.Parse(number.ToString());
        }
    }
