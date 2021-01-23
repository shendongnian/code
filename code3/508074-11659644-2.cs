    public static string Format(IFormatProvider provider, string format, params object[] args)
    {
        StringBuilder sb = new StringBuilder();
        // Break up the format string into an array of tokens
        Token[] tokens = ParseFormatString(format);
        foreach (Token token in tokens)
        {
            switch (token.TokenType)
            {
                // A Text token is just some text to output directly
                case TokenType.Text:
                    sb.Append(token.Text);
                    break;
                // An Index token represents something like {0} or {2:format}
                //  token.Index is the argument index
                //  token.FormatText is the format string inside ('' in the first example, 'format' in the second example)
                case TokenType.Index:
                    {
                        object arg = args[token.Index];
                        IFormattable formattable = arg as IFormattable;
                        if (formattable != null && token.FormatText.Length > 0)
                        {
                            // If the argument is IFormattable we pass it the format string specified with the index
                            sb.Append(formattable.ToString(token.FormatText, provider));
                        }
                        else
                        {
                            // Otherwise we just use Object.ToString
                            sb.Append(arg.ToString());
                        }
                    }
                    break;
            }
        }
        return sb.ToString();
    }
