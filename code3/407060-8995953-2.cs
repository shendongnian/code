    public List<T[]> GetSubArrays<T>(T[] array, T[] separator)
        where T : IEquatable<T>
    {
        int maxSepIndex = array.Length - separator.Length;
        var list = new List<T[]>();
        for (int i = 0; i <= array.Length; ) {
            // Get index of next separator or array.Length if none is found
            int sepIndex;
            for (sepIndex = i; sepIndex <= maxSepIndex; sepIndex++) {
                int k;
                for (k = 0; k < separator.Length; k++) {
                    if (!array[sepIndex + k].Equals(separator[k])) {
                        break;
                    }
                }
                if (k == separator.Length) { // Separator found at sepIndex
                    break;
                }
            }
            if (sepIndex > maxSepIndex) { // No separator found, subarray goes until end.
                sepIndex = array.Length;
            }
    
            int lenSubarray = sepIndex - i;
            T[] subarray = new T[lenSubarray];
            Array.Copy(array, i, subarray, 0, lenSubarray);
            list.Add(subarray);
            i = sepIndex + separator.Length;
        }
        return list;
    }
