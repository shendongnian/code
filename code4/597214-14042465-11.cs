    public static String SpinNoRE(String text)
    {
        int i;  // stores index of current open brace.
        int j;  // stores index of current close brace.
        int e;  // stores index of earliest untouched open brace.
        
        // helpers.
        char[] curls = new char[] {'{', '}'};
        Random rand = new Random((int)DateTime.Now.Ticks);
        // hack to prevent ArgumentOutOfRangeExceptions without having to check.
        text += '~';
        
        // index of "earliest untouched open brace" is unknown at start.
        e = -1;
        
        do
        {
            i =  e;
            e = -1;
            
            // loop as long as an open brace is found.
            while ((i = text.IndexOf('{', i+1)) != -1)
            {
                j = i;
                
                // loop as long as a brace is found and it is not a close brace.
                while ((j = text.IndexOfAny(curls, j+1)) != -1 && text[j] != '}')
                {
                    // means nested spintax was found; make j (the inner open
                    // brace) the "new" i and continue search for close brace.
                    
                    // nested spintax found; we're going to skip the current
                    // open brace in favor of this new one; but remember the
                    // index of the current open brace if it's the first such
                    // to be skipped; make j the "new" i; continue the search.
                    if (e == -1) e = i;
                    i = j;
                }
                
                // if close brace found, process spintax.
                if (j != -1)
                {
                    parts = text.Substring(i+1, (j-1)-(i+1-1)).Split('|');
                    text = text.Remove(i, j-(i-1)).Insert(i, parts[rand.Next(parts.Length)]);
                }
            }
        }
        // loop as long as an earlier untouched open brace exists (decrement e
        // before looping: the next loop begins its search at "i+1" == "e+1").
        while (e-- != -1);
        
        // undo aforementioned hack and return.
        return text.Remove(text.Length-1);
    }
