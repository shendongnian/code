    private static void Permutations(string str, string perm, int i)
    {
        if (i == str.Length)
            Console.WriteLine(perm);
        for (int k = str.Length - 1; k >= 0; k--) {
            int lenPerm = perm.Length;
            for (int j = 0; j < lenPerm; j++) {
                if (k >= 0 && perm[j] == str[k])
                    k--;
            }
            if (k >= 0)
                Permutations(str, perm + str[k], i++);
        }
    }
    public static void Start()
    {
        string st = "123";
        Permutations(st, "", 0);
    }
