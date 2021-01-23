    using System;
    namespace ConsoleApplication2
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                Random rng = new Random();
                for (int i = 0; i < 10; ++i)
                {
                    string randomString = RandomString(16, chars, rng);
                    Console.WriteLine(randomString);
                }
            }
            public static string RandomString(int n, char[] chars, Random rng)
            {
                Shuffle(chars, rng);
                return new string(chars, 0, n);
            }
            public static void Shuffle(char[] array, Random rng)
            {
                for (int n = array.Length; n > 1; )
                {
                    int k = rng.Next(n);
                    --n;
                    char temp = array[n];
                    array[n] = array[k];
                    array[k] = temp;
                }
            }
        }
    }
