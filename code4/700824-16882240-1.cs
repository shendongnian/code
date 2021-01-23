            int print = 3;
            int skip = 2;
            string str = "ABCDEFGHILKL";
            StringBuilder stringBuilder = new StringBuilder();
            string res = String.Empty;
            int i = 0;
            while (i < str.Length)
            {
                stringBuilder.Append(str.Substring(i, Math.Min(print, str.Length - i)));
                i += print + skip;
            }
            Console.WriteLine(stringBuilder.ToString());
