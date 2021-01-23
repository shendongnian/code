            string s = "this is a test";
            string[] words = s.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                for (int j = words[i].Length -1; j >= 0;j--)
                {
                    sb.Append(words[i][j]);
                }
                sb.Append(" ");
            }
            Console.WriteLine(sb);
