     public static void SetLast(this List<int> ints, int newVal)
        {
             int lastIndex = ints.Count-1;
             ints[lastIndex] = newVal;
        }
