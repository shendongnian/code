    public int GetHashCode(bool[] x)
    {
        // Trivial case
        if (x.Length == 0) return 0;
        // Convert the bool array to a BitArray to use framework functions
        BitArray binary = new BitArray(x);
        //Determine the max # of 32-bit INTS this array represents
        int intLength = (x.Length-1)/32 + 1;
        int [] ints = new int[intLength];
        // Copy each block of 32-bits to an int
        binary.CopyTo(ints, 0);
        // Take the exclusive OR of each int and return the result's hash code
        return ints.Aggregate((i1, i2) => i1 ^ i2).GetHashCode();
    }
