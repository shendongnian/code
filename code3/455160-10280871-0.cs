        public static int FindFirstUpper(string text)
        {
            for (int i = 0; i < text.Length; i++)
                if (Char.IsUpper(text[i]))
                    return i;
            return -1;
        }
