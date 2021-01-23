    /// <summary>
    /// Checks if the array contains the given value.
    /// </summary>
    public static bool contains<T>(T[] values, T value) {
        for (int s = 0, sl = values.Length; s < sl; s++) {
            if (values[s].Equals(value)) {
                return true;
            }
        }
        return false;
    }
