    // First split id and views part.
    String[] firstSplit = v.Split(',');
    // Get the respected value for each part.
    String id    = firstSplit[0].Split('=')[1].Trim();
    String views = firstSplit[1].Split('=')[1].Trim().Replace("}","");
