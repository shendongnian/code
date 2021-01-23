    public static int Occurences(string input)
    {
        // Put all smileys into an array.
        var smileys = SmileyDAL.GetAll().Select(x => x.Key).ToArray();
        // Split the string on each smiley.
        var split = input.Split(smileys, StringSplitOptions.None);
        // The number of occurences equals the length less 1.
        return split.Length - 1;
    } 
