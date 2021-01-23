    IEnumerable<string> SplitByCharacterTypeCamelCase(string input)
    {
        if (String.IsNullOrEmpty(input)) throw new ArgumentNullException("input");
        string segment = input[0].ToString();
        System.Globalization.UnicodeCategory cat = Char.GetUnicodeCategory(input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            Console.WriteLine(cat.ToString());
            var tc = Char.GetUnicodeCategory(input[i]);
            if (tc == cat)
            {
                segment += input[i];
            }
            else if(cat == System.Globalization.UnicodeCategory.UppercaseLetter &&
                     tc == System.Globalization.UnicodeCategory.LowercaseLetter)
            {
                segment += input[i];
                cat = tc;
            }
            else
            {
                yield return segment;
                segment = input[i].ToString();
                cat = tc;
            }
        }
        yield return segment;
    }
