    const string input = "hello hllo helo";
    Regex regex = new Regex("^h.*o$");
    for (int startIndex = 0; startIndex < input.Length - 1; startIndex++)
    {
        for (int endIndex = startIndex + 1; endIndex <= input.Length; endIndex++)
        {
            string substring = input.Substring(startIndex, endIndex - startIndex);
            if (regex.IsMatch(substring))
                Console.WriteLine(substring);
        }
    }
