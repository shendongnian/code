    for (int i = 1; i <= doc.TextFrames.Count; i++)
    {
        Illustrator.TextFrame tF = doc.TextFrames[i];
        Illustrator.TextFont objFont = tF.TextRange.CharacterAttributes.TextFont;
        double size = tF.TextRange.CharacterAttributes.Size;
        Console.WriteLine("Size: {0}, FontName: {1})", size, objFont.Name);
    }
