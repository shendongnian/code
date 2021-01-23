    static Regex reg = new Regex(@"\{([^\{\}]*)\}", RegexOptions.Compiled);
    static Random rand = new Random();
    public static String Spin(String text)
    {
        while (true)
        {
            Match m = reg.Match(text);
            if (!m.Success) break;
            String[] parts = m.Groups[1].Value.Split('|');
            int i = rand.Next(parts.Length);
            text = text.Substring(0, m.Index) + parts[i] + text.Substring(m.Index + m.Length);
        }
        return text;
  }
