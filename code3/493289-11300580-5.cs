    public static string UndoEncodingMistake(string mangledString, Encoding mistake, Encoding correction)
    {
        // the inverse of `mistake.GetString(originalBytes);`
        byte[] originalBytes = mistake.GetBytes(mangledString);
        return correction.GetString(originalBytes);
    }
    UndoEncodingMistake("d\u00C3\u00A9j\u00C3\u00A0", Encoding(1252), Encoding.UTF8);
