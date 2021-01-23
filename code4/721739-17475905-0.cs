    string[] splitString;
    if (usedDelimiter != null)
        splitString = sLongName.Split(usedDelimiter.Value);
    else
        splitString = new string[] { sLongName };
