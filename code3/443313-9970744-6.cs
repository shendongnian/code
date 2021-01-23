        static string GetName1(string objString)
        {
            return Regex.Replace(objString, "[^a-zA-Z&-]+", "");
        }
        static string GetName2(string objString)
        {
            return Regex.Replace(objString, "[^a-zA-Z&-]+", "", RegexOptions.Compiled);
        }
        static string GetName3(string objString)
        {
            var sb = new StringBuilder(objString.Length);
            foreach (char c in objString)
                if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '-' || c == '&'))
                    sb.Append(c);
            return sb.ToString();
        }
        static string GetName4(string objString)
        {
            char[] c = objString.ToCharArray();
            int pos = 0;
            int writ = 0;
            while (pos < c.Length)
            {
                char curr = c[pos];
                if (!((curr >= 'A' && curr <= 'Z') || (curr >= 'a' && curr <= 'z') || curr == '-' || curr == '&'))
                {
                    c[writ++] = c[pos];
                }
                pos++;
            }
            return new string(c, 0, writ);
        }
        unsafe static string GetName5(string objString)
        {
            char* buf = stackalloc char[objString.Length];
            int writ = 0;
            fixed (char* sp = objString)
            {
                char* pos = sp;
                while (*pos != '\0')
                {
                    char curr = *pos;
                    if (!((curr >= 'A' && curr <= 'Z') ||
                        (curr >= 'a' && curr <= 'z') ||
                         curr == '-' || curr == '&'))
                        buf[writ++] = curr;
                    pos++;
                }
            }
            return new string(buf, 0, writ);
        }
