    public enum DuplicateKeyHandling
    {
        Skip,
        Overwrite,
        Throw
    }
    /// <summary>
    /// Combines two dictionaries into one dictionary. The contents of the resulting dictionary depends on the <paramref name="duplicateKeyHandling"/> parameter.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries</typeparam>
    /// <param name="this"></param>
    /// <param name="other">The dictionary to combine this one with</param>
    /// <param name="duplicateKeyHandling">Specifies how to react if the <paramref name="other"/> dictionary contains keys that are already in this dictionary</param>
    /// <returns>A new dictionary containing the combined key-value-pairs of both source dictionaries</returns>
    public static Dictionary<TKey, TValue> Combine<TKey, TValue>(this Dictionary<TKey, TValue> @this, Dictionary<TKey, TValue> other, DuplicateKeyHandling duplicateKeyHandling = DuplicateKeyHandling.Skip)
    {
        var result = new Dictionary<TKey, TValue>(@this);
        foreach (KeyValuePair<TKey, TValue> kvp in other)
        {
            if (result.ContainsKey(kvp.Key))
            {
                if (duplicateKeyHandling == DuplicateKeyHandling.Overwrite)
                {
                    result[kvp.Key] = kvp.Value;
                }
                if (duplicateKeyHandling == DuplicateKeyHandling.Throw)
                {
                    throw new Exception("Duplicate key while combining dictionaries!");
                }
            }
            else
            {
                result.Add(kvp.Key, kvp.Value);
            }
        }
        return result;
    }
