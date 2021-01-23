using System;
namespace temp1
{
    class Program
    {
        static string str = "proffession";
        static int n = str.Length;
        static string dupstr = "";
        static int cnt = 0;
        static void Main()
        {
            RepeatedCharsString(); 
        }
        public static void RepeatedCharsString()
        {
            for (int i = 0; i < n ; i++)
            {
                for(int j = i + 1; j <= n-1; j++)
                {
                    if (str[i] == str[j])
                    {
                        dupstr = dupstr + str[i];
                        cnt = cnt + 1;
                    }
                }                
            }
            Console.WriteLine("Repeated chars are: " + dupstr);
            Console.WriteLine("No of repeated chars are: " + cnt);
        }
    }
}
