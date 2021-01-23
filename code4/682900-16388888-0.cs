    String[] lines = fileContents.Split({'\n'}); // split the content into separate lines
    bool wasEmpty = false;
    foreach (String line in lines) {
        line = line.Trim(); // remove leading/trailing whitespaces
        if (line.Length == 0) { // line is empty
            if (wasEmpty) { // last line was empty, too
                // init a new dataset
            }
            else
                wasEmpty = true;
            continue; // skip to next entry
        }
        wasEmpty = false;
        String content = line.split({':'}); // split the line into a key/value pair
        if (content.Length != 2) // not exactly two entries
            continue; // skip
        // content[0] now has the "key" (like "Lat/Long")
        // content[1] now has the "value" (like "18.38891, -66.12175")
        // both can be evaluated using regular expressions
    }
