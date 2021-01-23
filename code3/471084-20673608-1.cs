    static void Main(string[] args)
        {
           
            int f = 0;
            Console.WriteLine("enter the string");
            string s = Console.ReadLine();
            Console.WriteLine("enter the word to be searched");
            string a = Console.ReadLine();
            int l = s.Length;
            int c = a.Length;
            for (int i = 0; i < l; i++)
            {
                if (s[i] == a[0])
                {
                    for (int K = i + 1, j = 1; j < c; j++, K++)
                    {
                        if (s[K] == a[j])
                        {
                            f++;
                        }
                    }
                }
            }
            if (f == c - 1)
            {
                Console.WriteLine("matching");
            }
            else
            {
                Console.WriteLine("not found");
            }
            Console.ReadLine();
        }
