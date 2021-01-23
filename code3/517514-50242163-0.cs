    protected String ReplaceChars(String sIn)
    {
        int replChar = sIn.IndexOfAny(badChars);
        if (replChar < 0)
            return sIn;
        // Don't even bother making a copy unless you know you have something to swap
        StringBuilder sb = new StringBuilder(sIn, 0, replChar, sIn.Length + 10);
        while (replChar >= 0 && replChar < sIn.Length)
        {
            char? c = sIn[replChar];
            string s = null;
            // This approach lets you swap a char for a string or to remove some
            // If you had a straight char for char swap, you could just have your repl chars in an array with the same ordinals and do it all in 2 lines matching the ordinals.
            switch (c)
            {
                case "^": c = "Č";
                ...
                case '\ufeff': c = null; break;
            }
            if (s != null) sb.Append(s);
            else if (c != null) sb.Append(c);
            replChar++; // skip over what we just replaced
            if (replChar < sIn.Length)
            {
                int nextRepChar = sIn.IndexOfAny(badChars, replChar);
                sb.Append(sIn, replChar, (nextRepChar > 0 ? nextRepChar : sIn.Length) - replChar);
                replChar = nextRepChar;
            }
        }
        return sb.ToString();
    }
