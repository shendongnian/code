    using System.Linq;
    class Program {
        static int FancyQuestion(string value) {
            value = value.ToLowerInvariant();
            for (int i = 1; i < value.Length - 1; ++i) {
                string left = value.Substring(0, i);
                string right = value.Substring(i + 1);
                string left_reversed = new string(left.ToCharArray().Reverse().ToArray());
                if (right == left_reversed) {
                    return i;
                }
            }
            return -1;
        }
        // New version: in fact, we are only looking for palindromes
        // of odd length
        static int FancyQuestion2(string value) {
            value = value.ToLowerInvariant();
            if (value.Length % 2 == 0) {
                return -1;
            }
            int i = (int)(value.Length / 2);
            string left = value.Substring(0, i);
            string right = value.Substring(i + 1);
            string left_reversed = new string(left.ToCharArray().Reverse().ToArray());
            if (right == left_reversed) {
                return i;
            }
            return -1;
        }
        static void Main(string[] args) {
            int i1 = FancyQuestion2("xx"); // -1
            int i2 = FancyQuestion2("racecar"); // 3
            int i3 = FancyQuestion2("banana"); // -1
        }
    }
