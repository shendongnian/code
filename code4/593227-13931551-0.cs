    using System;
    namespace Crypto
    {
        public class Base64
        {
            private const String STANDARD_FIRST_62_CHARS=
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ"+
                    "abcdefghijklmnopqrstuvwxyz"+
                    "0123456789";
            public const String STANDARD_RADIX_STRING=
                    STANDARD_FIRST_62_CHARS + "+/";
            public const String RFC4648_RADIX_STRING=
                    STANDARD_FIRST_62_CHARS + "-_";
            private const char padding='=';
            private char[]radix_chars;
            public Base64(String radix_string)
            {
                radix_chars=radix_string.ToCharArray();
            }
            public Base64():this(STANDARD_RADIX_STRING)
            {
            }
            public String decode(String str)
            {
                String binary_str = "";
                char[]chars = str.ToCharArray();
                int i=0;
                for(;i<chars.Length && chars[i]!=padding;++i)
                {
                    int index = indexOf(chars[i]);
                    String bin_of_index = DecimalToBinary(index,6);
                    binary_str = binary_str + bin_of_index;
                }
                binary_str = binary_str.Substring(0,binary_str.Length - (2*(chars.Length-i)));
                str = "";
                for(i = 0 ; i < binary_str.Length ; i = i+8)
                {
                    String bin_str = binary_str.Substring(i,8);
                    int char_point = Convert.ToInt16(bin_str,2);
                    str = str + ((char)char_point);
                }
                return str;
            }
            public String encode(String str)
            {
                // TODO
                return null;
            }
            private String DecimalToBinary(int value,int length)
            {
                String bin_string = Convert.ToString(value, 2);
                length = length - bin_string.Length;
                while(length > 0 )
                {
                    bin_string = "0"+bin_string;
                    --length;
                }
                return bin_string;
            }
            private int indexOf(char c)
            {
                for(int index=0; index < radix_chars.Length ; ++ index)
                    if(c == radix_chars[index])
                        return index;
                return -1;
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
            Crypto.Base64 b = new Crypto.Base64(Crypto.Base64.RFC4648_RADIX_STRING);
            Console.WriteLine(b.decode("x8QeoAdVOAwpKHAeXIxEticayZLMx7RP_baVdSpDSLLea5TZMxRT-IX93lA05MEUzmwtOvd6WLRBluLchZz2EJSHsFfxxtPQF1VEFv4rA5w="));
        }
    }
