    HList findHListentry(string letter)
    {
        if (string.IsNullOrWhiteSpace(letter))
            throw new ArgumentNullException("letter");
        HList result = listentry.Find(
            delegate(HList bk)
            {
                return bk.letter == letter;
            }
        );
        
        return result;
    }
