    // I imagine you'd want to start a list here
    // that will hold the contents of your loops' results.
    List<string> resultsList = new List<string>();
    foreach(var tableCell in tr.Cells)
    {
        // May want to start another list here in case there are multiple blocks.
        List<string> blockContent = new List<string>();
        foreach(var block in tableCell.Blocks)
        {
            // Probably want to start another list here to which to add in the next loop.
            List<string> inlineContent = new List<string>();
            foreach(var inline in block.Inlines)
            {
                // Implement whatever in here depending the type of inline,
                // such as Span, Run, InlineUIContainer, etc.
                // I just assumed it was text.
                inlineContent.Add(new TextRange(inline.ContentStart, inline.ContentEnd).Text);
            }
            blockContent.Add(string.Join("", inlineContent.ToArray()));
        }
        resultsList.Add(string.Join("\n", blockContent.ToArray()));
    }
