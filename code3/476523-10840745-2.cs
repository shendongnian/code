    int[] GetPermutation(int size, int seed)
    {
        Random random = new Random(seed);
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
            array[i] = i;
        for (int i = array.Length; i > 1; i--)
        {
            int j = random.Next(i);
            int tmp = array[j];
            array[j] = array[i - 1];
            array[i - 1] = tmp;
        }
        return array;
    }
    Color[] Encrypt(Color[] input, string password)
    {
        int seed = password.GetHashCode();
        int[] perm = GetPermutation(input.Length, seed);
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
        int[] perm = GetPermutation(input.Length, seed);
        Color[] decrypted = new Color[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            decrypted[i] = input[perm[i]];
        }
        return decrypted;
    }
