    public static string StripHTMLTags(string str)
        {
            char[] array = new char[str.Length];
            int arrayIndex = 0;
            bool inside = false;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '<')
                {
                    inside = true;
                    continue;
                }
                if (c == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = c;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
