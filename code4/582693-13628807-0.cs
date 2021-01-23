    public static string OrDefaultFor(this string input,
                                      string invalidInput,
                                      string replacement)
    {
        return input == invalidInput ? replacement : input;
    }
