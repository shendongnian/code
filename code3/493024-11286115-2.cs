    void Main()
    {
        var input = new[] { "abc", "bcd", "xyz", "zzz", };
        var except = new[] { "abc", "xyz", };
        
        ExceptSortedInputs(input, except).Dump();
    }
    
    // Define other methods and classes here
    public static IEnumerable<string> ExceptSortedInputs(IEnumerable<string> inputSequence, IEnumerable<string> exceptSequence)
    {
        var exceptEnumerator = exceptSequence.GetEnumerator();
        var exceptStillHasElements = exceptEnumerator.MoveNext();
    
        var inputEnumerator = inputSequence.GetEnumerator();
        var inputStillHasElements = inputEnumerator.MoveNext();
        
        while (inputStillHasElements)
        {
            if (exceptStillHasElements == false)
            {
                // since we exhausted the except sequence, we know we can safely return any input elements
                yield return inputEnumerator.Current;
                inputStillHasElements = inputEnumerator.MoveNext();
                continue;
            }
            
            // need to compare to see which operation to perform
            switch (String.Compare(inputEnumerator.Current, exceptEnumerator.Current))
            {
                case -1:
                    // except sequence is already later, so we can safely return this
                    yield return inputEnumerator.Current;
                    inputStillHasElements = inputEnumerator.MoveNext();
                    break;
                    
                case 0:
                    // except sequence has a match, so we can safely skip this
                    break;
                    
                case 1:
                    // except sequence is behind - we need to move it forward
                    exceptStillHasElements = exceptEnumerator.MoveNext();
            }
        }
    }
