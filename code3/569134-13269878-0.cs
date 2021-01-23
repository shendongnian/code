    dynamic array = Array.CreateInstance(input[0].GetType(), input.Length);
    for (int i = 0; i < input.Length; i++)
    {
        array[i] = input[i];
    }
