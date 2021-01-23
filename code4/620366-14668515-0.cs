    public static bool TryGetTags(string tagsInput, out string[] tags)
    {
        Regex regex = new Regex(@"^[\w_-]+$");
        tags = tagsInput.Split(',')  // Rule 6
                        .Select(tag => tag.Trim())
                        .ToArray();
        if (tags.Last() == "")
            tags = tags.Take(tags.Length - 1).ToArray();  // Rule 7
        if (tags.Any(tag => tag == ""))  // (no empty tag allowed except last one)
            return false;
        if (tags.Length > 9)
            return false;  // Rule 2
        if (tags.Any(tag => tag.Length > 30))
            return false;  // Rule 4
        if (tags.Distinct().Count() != tags.Length)
            return false;  // Rule 3
        if (tags.Any(tag => !regex.IsMatch(tag)))
            return false;  // Rule 5
        return true;
    }
