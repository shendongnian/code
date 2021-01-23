    List<int> GetPermutation(int size, int seed)
    {
        Random rand = new Random(seed);
        List<int> sorted = new List<int>(size);
        List<int> perm = new List<int>(size);
        for (int i = 0; i < size; i++)
            sorted.Add(i);
        int randitem;
        for (int i = 0; i < size; i++)
        {
            randitem = rand.Next(sorted.Count);
            perm.Add(sorted[randitem]);
            sorted.RemoveAt(randitem);
        }
        return perm;
    }
    Color[] Encrypt(Color[] input, string password)
    {
        int seed = password.GetHashCode();
        List<int> perm = GetPermutation(input.Length, seed);
        Color[] encrypted = new Color[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            encrypted[perm[i]] = input[i];
        }
        return encrypted;
    }
    Color[] Decrypt(Color[] input, string password)
    {
        int seed = password.GetHashCode();
        List<int> perm = GetPermutation(input.Length, seed);
        Color[] decrypted = new Color[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            decrypted[i] = input[perm[i]];
        }
        return decrypted;
    }
