    Console.WriteLine("Please enter a word:");
    string s = Console.ReadLine();
    bool found = false;
    char[] chars = new char[s.Length];
    for (int i = 0; i < s.Length; i++)
    {
        if (Char.IsLetter(s[i]) && !found)
        {
             chars[i] = s[i].ToString().ToUpper()[0];
             found = true;
        }
        else
        {
            chars[i] = s[i];
        }
    }
    s = new String(chars);
    Console.WriteLine(s);
