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
        static void Main(string[] args) {
            int i1 = FancyQuestion("xx"); // -1
            int i2 = FancyQuestion("racecar"); // 3
            int i3 = FancyQuestion("banana"); // -1
        }
    }
