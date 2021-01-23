    for (int i = 0; i <= input.Length/4; i += 2048)
    {
        // ...
        int iCopy = i;
        var test = Task.Factory.StartNew(() => addReferences(arrayToReference, iCopy));
        // ...
    }
