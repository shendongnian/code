    string s = "This is sweeeeeeeeeeeeeeeet! And something more.";
    string[] words = s.Split(' ');
    StringBuilder sb = new StringBuilder();
    foreach (string word in words)
    {
        char[] chars = word.ToCharArray();
        if (chars.Length > 6)
        {
            for (int i = 0; i < 6; i++)
            {
                sb.Append(chars[i]);
            }
            sb.Append("...").Append(" ");
        }
        else { sb.Append(word).Append(" "); }
    }
    sb.Remove(sb.Length - 1, 1);
    Console.WriteLine(sb.ToString());
