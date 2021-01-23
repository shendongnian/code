    Regex TryParseRegex(string input) {
        try {
            return new Regex(input);
        }
        catch (ArgumentException) {
            return null;
        }
    }
