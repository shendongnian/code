    public static string CamelCaseToDisplayName<T>(this T enumeration)
        {
            string name = enumeration.ToString();
            for (int i = 1; i < name.Length; i++)
            {
                char c = name[i];
                if (c >= 'A' && c <= 'Z')
                {
                    name.Remove(i, 1);
                    name.Insert(i++, ((char)(c + 0x30)).ToString());
                    name.Insert(i, " ");
                }
            }
            return name;
        }
