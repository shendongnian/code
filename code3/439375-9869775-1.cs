    String email = "awesome1@email.com";
    String[] tokens = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
    const String allowed = "0123456789";
    String part1 = "";
    String numberStr = "";
    foreach (char c in tokens[0].Reverse())
    {
        if (allowed.Contains(c) && part1.Length==0)
        {
            numberStr += c;
        }
        else
        {
            part1 += c;
        }
    }
    part1 = new String(part1.Reverse().ToArray());
    int number = int.Parse(new String(numberStr.Reverse().ToArray()));
    String result = String.Format("{0}{1}@{2}", part1, number++, tokens[1]);
