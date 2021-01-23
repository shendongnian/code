    public string Replace(input, replacement)
    {
        // find all the tags
        var regex = new Regex("(\[(?:position|/?item)\])");
        var matches = regex.Matches(input);
        // loop through the tags and build up the output string
        var builder = new StringBuilder();
        int lastIndex = 0;
        int nestingLevel = 0;
        foreach(var match in matches)
        {
            // append everything since the last tag;
            builder.Append(input.Substring(lastIndex, (match.Index - lastIndex) + 1));
            
            switch(match.Value)
            {
                case "[item]":
                    nestingLevel++;
                    builder.Append(match.Value);
                    break;
                case "[/item]":
                    nestingLevel--;
                    builder.Append(match.Value);
                    break;
                case "[position]":
                    // Append the replacement text if we're outside of any [item]/[/item] pairs
                    // Otherwise append the tag
                    builder.Append(nestingLevel == 0 ? replacement : match.Value);
                    break;
            }
            lastIndex = match.Index + match.Length;
        }
        
        builder.Append(input.Substring(lastIndex));
        return builder.ToString();
    }
