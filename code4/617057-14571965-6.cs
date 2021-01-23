    private static string ConvertStringToMorse(string letters)
    {
        var result = string.Join("|",
            letters
                .Select(ConvertTextToMorse)
                .Where(morse => !string.IsNullOrEmpty(morse)));
        return result;
    }
