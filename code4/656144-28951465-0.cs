        static void Main(string[] args)
        {
            string sentence = "My name is Archit Patel";
            StringBuilder sb = new StringBuilder();
            string[] split = sentence.Split(' ');
            for (int i = split.Length - 1; i > -1; i--)
            {
                sb.Append(split[i]);
                sb.Append(" ");
            }
            Console.WriteLine(sb);
            Console.ReadLine();
        }
    }
