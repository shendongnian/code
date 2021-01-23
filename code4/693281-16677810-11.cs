    String result = Regex.Replace(
        text,
        @"\[%RC:(\d+)%\]",
        match => { 
           // This does the same thing, but with more lines of code.
           // Of course, you could get way more fancy with it as well.
           String numericValueAsString = match.Groups[1].Value;
           Int32 numericValue = Int32.Parse(numericValueAsString);
           String dictionaryValue = dict[numericValue];
           // Same as above
           return dictionaryValue;
        });
