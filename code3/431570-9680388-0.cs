    public static byte[] JsonStringToByteArray(string jsonString)
    {
        jsonString = jsonString.Substring(1, jsonString.Length - 2);
        var arr = jsonString.Split(',');
        var bResult = new byte[arr.Length];
        for (var i = 0; i < arr.Length; i++)
            bResult[i] = byte.Parse(arr[i]);
        return bResult;
    }
