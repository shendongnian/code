    public static int[] GetIntArrayFromStringArray(string[] stringArray)
        {
            int i = 0;
            int[] ints;
            int num;
            if (stringArray == null && stringArray.Length > 0)
            {
            ints = new int[stringArray.Length]
            foreach (var str in stringArray)
            {
                if (string.IsNullOrEmpty(str) && int.TryParse(str, num))
                {
                ints[i++] = num;
                }  
            }
            }
            return ints;
        }
