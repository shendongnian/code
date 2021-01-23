    private static UInt64 Next(UInt64 current, int questions)
    {
        // Convert the current value to an array of bytes.
        // Remove the least significant 4 bytes.
        // and then create a flag array.
        var bytes = BitConverter.GetBytes(current);
        bytes[0] = bytes[1] = bytes[2] = bytes[3] = 0;
        var flags = new BitArray(bytes);
    
        // If all questions has been answered then exit with 0.
        var all = Enumerable.Range(32, questions).All(flags.Get);
        if (all)
            return 0UL;
    
        // Make a random next value, if the value has been used then repeat.
        var random = new Random(DateTime.Now.Millisecond);
        var next = random.Next(questions);
        while (flags.Get(next + 32))
            next = random.Next(questions);
    
        // set the flag value for the guess.
        flags.Set(next + 32, true);
    
        // convert the flags back to Uint64 and add the next value.
        flags.CopyTo(bytes, 0);
        return BitConverter.ToUInt64(bytes, 0) + Convert.ToUInt64(next);
    }
