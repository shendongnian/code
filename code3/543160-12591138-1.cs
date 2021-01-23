    bool IsValidFilename(string testName)
    {
     Regex containsABadCharacter = new Regex("[" + Regex.Escape(System.IO.Path.InvalidPathChars) + "]");
     if (containsABadCharacter.IsMatch(testName) { return false; };
     return true;
    }
