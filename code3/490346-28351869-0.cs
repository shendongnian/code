    public static class ContrivedUtils 
    {
        public static Int64 Permutations(char[] array)
        {
            if (null == array || array.Length == 0) return 0;
            Int64 permutations = array.Length;
            for (var pos = permutations; pos > 1; pos--)
                permutations *= pos - 1;
            return permutations;
        }
    }
