    Contact c = new Contact();
    string () tokens = input.Split(":".ToCharArray());
    if (tokens.Count < 5)
        return; // error
    // now strip the last word from each token
    c.Name = tokens(2).Substring(0, tokens(2).FindLastOf(" ".ToCharArray())).Trim();
    c.Last = tokens(3).Substring(0, tokens(3).FindLastOf(" ".ToCharArray())).Trim();
    c.Email = tokens(4).Trim();
