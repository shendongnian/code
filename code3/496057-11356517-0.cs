    string[] s = Directory.GetFiles(path);
            int i = 0;
            while (i < s.Length)
            {
                if (s[i].Substring((s[i].IndexOf(".") + 1), 3).Equals("zip"))
                {
                    Response.Write(s[i].ToString());
                    i = i + 1;
                }
            }
