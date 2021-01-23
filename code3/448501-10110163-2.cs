    public string ConvertExpression(string expression)
    {
        IEnumerator<string> tokens = Regex.Split(expression, @"\b")
                        .Where(s => s != "")
                        .GetEnumerator();
        if (tokens.MoveNext()) {
            return Parse(tokens);
        }
        return "";
    }
