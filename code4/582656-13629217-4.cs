    static class ExtensionMethods {
        public static string AsBits(this int b) {
            return Convert.ToString(b, 2).PadLeft(9, '0');
        }
    }
    class Program {
        static void Main() {
            var intArray = new[] {0, 64, 8, 8, 0, 12, 224, 0 };
            var intArray2 = (int[])intArray.Clone();
            DropDownBits(intArray2);
            for (var i = 0; i < intArray.Length; i++)
                Console.WriteLine("{0} => {1}", intArray[i].AsBits(),
                    intArray2[i].AsBits());
        }
        static void DropDownBits(int[] byteArray) {
            var changed = true;
            while (changed) {
                changed = false;
                for (var i = byteArray.Length - 1; i > 0; i--) {
                    var orgValue = byteArray[i];
                    byteArray[i] = (byteArray[i] | byteArray[i - 1]);
                    byteArray[i - 1] = (orgValue & byteArray[i - 1]);
                    if (byteArray[i] != orgValue) changed = true;
                }
            }
        }
    }
