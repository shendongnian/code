    /// <summary>
    /// Convert an argument array to an argument string for using
    /// with Process.StartInfo.Arguments.
    /// </summary>
    /// <param name="argument">
    /// The args to convert.
    /// </param>
    /// <returns>
    /// The argument <see cref="string"/>.
    /// </returns>
    public static string EscapeArguments(string argument)
    {
        using (var characterEnumerator = argument.GetEnumerator())
        {
            var escapedArgument = new StringBuilder();
            var backslashCount = 0;
            var needsQuotes = false;
            while (characterEnumerator.MoveNext())
            {
                switch (characterEnumerator.Current)
                {
                    case '\\':
                        // Backslashes are simply passed through, except when they need
                        // to be escaped when followed by a \", e.g. the argument string
                        // \", which would be encoded to \\\"
                        backslashCount++;
                        escapedArgument.Append('\\');
                        break;
                    case '\"':
                        // Escape any preceding backslashes
                        for (var c = 0; c < backslashCount; c++)
                        {
                            escapedArgument.Append('\\');
                        }
                        // Append an escaped double quote.
                        escapedArgument.Append("\\\"");
                        // Reset the backslash counter.
                        backslashCount = 0;
                        break;
                    case ' ':
                    case '\t':
                        // White spaces are escaped by surrounding the entire string with
                        // double quotes, which should be done at the end to prevent 
                        // multiple wrappings.
                        needsQuotes = true;
                        // Append the whitespace
                        escapedArgument.Append(characterEnumerator.Current);
                        // Reset the backslash counter.
                        backslashCount = 0;
                        break;
                    default:
                        // Reset the backslash counter.
                        backslashCount = 0;
                        // Append the current character
                        escapedArgument.Append(characterEnumerator.Current);
                        break;
                }
            }
            // No need to wrap in quotes
            if (!needsQuotes)
            {
                return escapedArgument.ToString();
            }
            // Prepend the "
            escapedArgument.Insert(0, '"');
            // Escape any preceding backslashes before appending the "
            for (var c = 0; c < backslashCount; c++)
            {
                escapedArgument.Append('\\');
            }
            // Append the final "
            escapedArgument.Append('\"');
            return escapedArgument.ToString();
        }
    }
    /// <summary>
    /// Convert an argument array to an argument string for using
    /// with Process.StartInfo.Arguments.
    /// </summary>
    /// <param name="args">
    /// The args to convert.
    /// </param>
    /// <returns>
    /// The argument <see cref="string"/>.
    /// </returns>
    public static string EscapeArguments(params string[] args)
    {
        var argEnumerator = args.GetEnumerator();
        var arguments = new StringBuilder();
        if (!argEnumerator.MoveNext())
        {
            return string.Empty;
        }
        arguments.Append(EscapeArguments((string)argEnumerator.Current));
        while (argEnumerator.MoveNext())
        {
            arguments.Append(' ');
            arguments.Append(EscapeArguments((string)argEnumerator.Current));
        }
        return arguments.ToString();
    }
