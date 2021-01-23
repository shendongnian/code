    // This is static so we don't recreate it every time.
    private static Random _rnd;
    static void Main(string[] args)
    {
        _rnd = new Random();
        // You can declare and initialise a variable in one statement.
        // In this case you want the array size to be 6, not 7!
        Int32[] lotoNumbers = new Int32[6];
        // Generate 10 sets of 6 random numbers
        for (int i = 0; i < 10; i++)
        {
            // Use a meaningful name for your iteration variable
            // In this case I used 'idx' as in 'index'
            // Arrays in c# are 0-based, so your lotto array has
            // 6 elements - [0] to [5]
            for (Int32 idx = 0; idx < 6; idx++)
            {
                // Keep looping until we have a unique number
                int proposedNumber;
                do
                {
                    proposedNumber = _rnd.Next(1, 50);
                } while (lotoNumbers.Contains(proposedNumber));
                // Assign the unique proposed number to your array
                lotoNumbers[idx] = proposedNumber;
            }
        }
    }
