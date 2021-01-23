    for (int i = 0; i < namesArray.Length; ++i) 
    {
        if (string.IsNullOrWhiteSpace(namesArray[i]))
        {
            namesArray[i] = EncValue.ToString();
        }
    }
