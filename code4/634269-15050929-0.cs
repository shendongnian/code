    // Is it "odpad" ?
    if (att.InnerText == "odpad!")
    {
        b[j] = att.InnerText;
    
    }
    // .. If not, is it starred?
    else if (att.Attributes["alt"] != null)
    {
        b[j] = att.Attributes["alt"].Value;
    
    }
    // If none of above, it must be this (default)
    else
    {
           b[j] = "without user evaluation";
    
    }
