    string myString = "aa bbb cccc dd";
    var result = this.GetCharacters(myString, 5);
    string output = new string(result.ToArray());
    public IEnumerable<char> GetCharacters(string input, int coeff)
    {
        foreach (char c in input)
        {
            if (Char.IsWhiteSpace(c))
            {
                int counter = coeff;
                while (counter-- > 0)
                {
                    yield return c;
                }
            }
            else
            {
                yield return c;
            }
        }
    }
