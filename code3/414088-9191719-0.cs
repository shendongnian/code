    namespace Interop_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                char[] text = new char[10];
                for (int i = 0; i < 10; i++)
                    text[i] = (char)('A' + i);
                test(new string(text));
            }
    		
            [DllImport("interop_test_dll.dll", CharSet = CharSet.Ansi)]
            private static extern void test(
    			[MarshalAs(UnmanagedType.LPStr, CharSet = CharSet.Ansi)] string text);
        }
    }
