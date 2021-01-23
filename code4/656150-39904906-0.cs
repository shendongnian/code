    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("abcd efg hijk");
            Reverse(sb, 0 , sb.Length - 1);
            Console.WriteLine(sb);
            ReverseWords(sb);
            Console.WriteLine(sb);
            ReverseWordOrder(sb);
            Console.WriteLine(sb);
        }
        static void Reverse(StringBuilder sb, int startIndex, int endIndex)
        {
            for(int i = startIndex; i <= (endIndex - startIndex) / 2 + startIndex; i++)
            {
                Swap(sb,i, endIndex + startIndex - i);
            }
        }
        private static void Swap(StringBuilder sb, int index1, int index2)
        {
            char temp = sb[index1];
            sb[index1] = sb[index2];
            sb[index2] = temp;
        }
        static void ReverseWords(StringBuilder sb)
        {
            int startIndex = 0;
            for (int i = 0; i <= sb.Length; i++)
            {
                if (i == sb.Length || sb[i] == ' ')
                {
                    Reverse(sb, startIndex, i - 1);
                    startIndex = i + 1;
                }
            }
        }
        static void ReverseWordOrder(StringBuilder sb)
        {
            Reverse(sb, 0, sb.Length - 1);
            ReverseWords(sb);
        }
    }
    }
