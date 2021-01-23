    private IEnumerable<string> Combinations()
    {
        //Let's just use a-c for a test run.
        string setOfChars = "abc";
        //Let's return for four characters to guess for. We can change this.
        char[] buffer = new char[4];
        //We'll change these indices and then use them to pick chars from
        //setOfChars to the corresponding place in buffer
        int[] setOfIndices = new int[buffer.Length];
        
        //set up initial position:
        for(int i = 0; i != buffer.Length; ++i)
            buffer[i] = setOfChars[0];
        
        //return our inital position.
        yield return new string(buffer);
        //Now for our actual combinations.
        for(int i = 0; i != buffer.Length; ++i)
        {
            if(++setOfIndices[i] == setOfChars.Length)
                //if we've pushed an index out of range, then set it back to zero.
                setOfIndices[i] = 0;
            else
            {
                //otherwise move our position for changing things back to zero
                i = -1;
                
                //and generate our new combination.
                for(int j = 0; j != buffer.Length; ++j)
                buffer[j] = setOfChars[setOfIndices[j]];
                yield return new string(buffer);
            }
        }
    }
