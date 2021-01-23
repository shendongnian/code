    string s = "My name is Archit Patel";
            string[] words = s.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                sb.Append(" ");
            }
            Console.WriteLine(sb);
