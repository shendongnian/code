    /// <summary>
    /// Checks if the array contains the given value.
    /// </summary>
    public static bool Contains<T>(T[] values, T value) {
        for (int s = 0, sl = values.Length; s < sl; s++) {
            if (object.Equals(values[s].value)) {
                return true;
            }
        }
        return false;
    }
