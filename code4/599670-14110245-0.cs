    public void CalculatePrimeNumbers(long MAX)
    {
        primeNumbers = new List<long>(); // empties the prime numbers list
        try
        {
            for (long i = 2; i < MAX + 1; i++) // from 2 to MAX
            {
                primeNumbers.Add(i); // fills the list with all numbers
            }
            double stopAt = Math.Sqrt((double)MAX); // create the 'stop'  number
    
            for (long N = 2; N <= stopAt; N++) // from N to 'stop' number
            {
                if (!primeNumbers.Contains(N)) // if N doesn't contain, continue
                {
                    continue;
                }
                for (long toRemove = 2 * N; toRemove < MAX + 1; toRemove += N)
                {
                    primeNumbers.Remove(toRemove); // removes all multiplications of N, 
                                  // excepting N
                }
            }
        }
        catch (OutOfMemoryException) // if out of memory, clears the memory, set the list to null and shows  a message 
        {
            primeNumbers = null;
            GC.Collect();
            MessageBox.Show("Out of memory. Try a smaller maximum number.");
    
            return;
        }
    }
