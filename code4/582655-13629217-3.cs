    static class ExtensionMethods {
        public static string AsBits(this byte b) {
            return Convert.ToString(b, 2).PadLeft(9, '0');
        }
    }
    class Program {
        static void Main() {
            var byteArray = new byte[] {0, 64, 8, 8, 0, 12, 224, 0};
            var byteArray2 = (byte[])byteArray.Clone();
            DropDownBits(byteArray2);
            for (var i = 0; i < byteArray.Length; i++)
                Console.WriteLine("{0} => {1}", byteArray[i].AsBits(), 
                    byteArray2[i].AsBits());
        }
        static void DropDownBits(byte[] byteArray) {
            var changed = true;
            while (changed) {
                changed = false;
                for (var i = byteArray.Length - 1; i > 0; i--) {
                    var orgValue = byteArray[i];
                    byteArray[i] = (byte) (byteArray[i] | byteArray[i - 1]);
                    byteArray[i - 1] = (byte) (byteArray[i - 1] & orgValue);
                    if (byteArray[i] != orgValue) changed = true;
                }
            }
        }
    }
