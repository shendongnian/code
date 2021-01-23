    using System.Linq;
    class Program {
        // New version: in fact, we are only looking for palindromes
        // of odd length
        static int FancyQuestion2(string value) {
            if (value.Length % 2 == 0) {
                return -1;
            }
            string reversed = new string(value.ToCharArray().Reverse().ToArray());
            if (reversed.Equals(value,  StringComparison.InvariantCultureIgnoreCase)) {
                return (int)(value.Length / 2);
            }
            return -1;
        }
        static void Main(string[] args) {
            int i1 = FancyQuestion2("noon"); // -1 (even length)
            int i2 = FancyQuestion2("racecar"); // 3
            int i3 = FancyQuestion2("WasItACatISaw"); // 6
        }
    }
