    public void Increment(BitArray bArray)
    {
        for (int i = 0; i < 32; i++)
        {
            bool previous = bArray[i];
            bArray[i] = !previous;
            if (!previous)
            {
                // Found a clear bit - now that we've set it, we're done
                return;
            }
        }
    }
