    private object GetResult(int keyIndex, int[] keys, Dictionary<int, object> inputDictionary)
    {
        Dictionary<int, object> nextDictionary = inputDictionary[keys[keyIndex]] as Dictionary<int, object>;
        object result;
        if (nextDictionary != null && keyIndex < keys.Length)
        {
            keyIndex++;
            return GetResult(keyIndex, keys, nextDictionary);
        }
        else if(!string.IsNullOrEmpty(inputDictionary[keys[keyIndex]].ToString()))
        {
            result = inputDictionary[keys[keyIndex]] as object;
            keyIndex++;
            return result;
        }
        return new object[] { "Failed" };
    }
