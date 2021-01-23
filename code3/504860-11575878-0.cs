    string test = TakePieceFromText("this is my data to work with", 2, 5);
    /// <summary>
    /// Takes the piece from text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="length">The length.</param>
    /// <returns>a piece of text</returns>
    private string TakePieceFromText(string text, int startIndex, int length)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentNullException("no text givin");
        string result = string.Empty;
        try
        {
            result = text.Substring(startIndex, length);
        }
        catch (Exception ex)
        { 
         // log exception
        }
        return result;
    }
