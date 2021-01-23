    using (var sr = new MemoryStream(Encoding.UTF8.GetBytes(serializedString)))
    {
        int line = 0;
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            line++;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (char.IsControl(c))
                    Console.WriteLine("Line " + line + ", char " + i + " is invalid char " + (int)c);
            }
        }
    }
