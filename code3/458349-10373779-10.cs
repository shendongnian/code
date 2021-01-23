    IEnumerable<string> parts = username.AllPartsOfLength(3)
        .Concat(realName.AllPartsOfLength(3))
        .Select(part => Regex.Escape(part));
    string regex = "(" + string.Join("|", parts) + ")";
    
    bool isPasswordOk = !Regex.Match(regex).Success;
