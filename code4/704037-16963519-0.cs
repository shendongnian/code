       public static void Reverse(string x)
            {
                string text = x;
                string reverse = string.Empty;
                foreach (char ch in text)
                {
                    reverse = ch + reverse;
                }
                Console.WriteLine(reverse);
            }
            public static void ReverseFast(string x)
            {
                string text = x;
                StringBuilder reverse = new StringBuilder();
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    reverse.Append(text[i]);
                }             
                Console.WriteLine(reverse);
            }
            public static void Main(string[] args)
            {
                int abcx = 100; // amount of abc's
                string abc = ""; 
                for (int i = 0; i < abcx; i++)
                    abc += "abcdefghijklmnopqrstuvwxyz";
                var x = new System.Diagnostics.Stopwatch();
                x.Start();
                Reverse(abc);
                x.Stop();
                string ReverseMethod = "Reverse Method: " + x.ElapsedMilliseconds.ToString();
                x.Restart();
                ReverseFast(abc);
                x.Stop();
                Console.Clear();
                Console.WriteLine("Method | Milliseconds");
                Console.WriteLine(ReverseMethod);
                Console.WriteLine("ReverseFast Method: " + x.ElapsedMilliseconds.ToString());
                System.Console.Read();
            }
