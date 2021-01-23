    // I don't think I'd use ?? like this, but that's not the point of the question.
    var unparsed = (overrrides ?? string.Empty).Split(new char[] { ';' }, 
                                                      StringSplitOptions.RemoveEmptyEntries);
    var parsed = unparsed.Select(x => ParsePair(x));
    ...
    static KeyValuePair<string, float> ParsePair(string text)
    {
        // Note that you could be more efficient using IndexOf/Substring
        string[] bits = text.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        if (bits.Length != 2)
        {
            throw new ArgumentException("Value should be a colon-separated key/float pair");
        }
        float value;
        if (!float.TryParse(bits[1], out value))
        {
            throw new ArgumentException("Cannot parse " + bits[1] + " as a float");
        }
        return new KeyValuePair<string, float>(bits[0], value);
    }
