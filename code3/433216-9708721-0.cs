    // This only needs to be initialized once.
    var invalidChars = Path.GetInvalidPathChars().Select(c => Regex.Escape(c.ToString()));
    Regex regex = new Regex(string.Join("|", invalidChars));
    // Replace all invalid characters with "_".
    userDir = regex.Replace(userDir, "_");
