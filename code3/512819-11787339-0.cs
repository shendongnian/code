    private string GetWordAtPointer(TextPointer textPointer)
    {
        return string.Join(string.Empty, GetWordCharactersBefore(textPointer), GetWordCharactersAfter(textPointer));
    }
    private void ReplaceWordAtPointer(TextPointer textPointer, string replacementWord)
    {
        textPointer.DeleteTextInRun(-GetWordCharactersBefore(textPointer).Count());
        textPointer.DeleteTextInRun(GetWordCharactersAfter(textPointer).Count());
        textPointer.InsertTextInRun(replacementWord);
    }
    private string GetWordCharactersBefore(TextPointer textPointer)
    {
        var backwards = textPointer.GetTextInRun(LogicalDirection.Backward);
        var wordCharactersBeforePointer = new string(backwards.Reverse().TakeWhile(c => !char.IsSeparator(c) && !char.IsPunctuation(c)).Reverse().ToArray());
        return wordCharactersBeforePointer;
    }
    private string GetWordCharactersAfter(TextPointer textPointer)
    {
        var fowards = textPointer.GetTextInRun(LogicalDirection.Forward);
        var wordCharactersAfterPointer = new string(fowards.TakeWhile(c => !char.IsSeparator(c) && !char.IsPunctuation(c)).ToArray());
        return wordCharactersAfterPointer;
    }
