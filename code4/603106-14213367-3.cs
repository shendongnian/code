    int i = 0;
    List<int> list = new List<int>();
    while (i < myNumber.Length)
    {
        if (i < myNumber.Length - 1 && (int)Char.GetNumericValue(myNumber[i + 1]) == 0)
        {
            list.Add((int)Char.GetNumericValue(myNumber[i]) * 10);
            i += 2;
        }
        else
        {
            list.Add((int)Char.GetNumericValue(myNumber[i]));
            i++;
        }  
    }
     
    return list.ToArray();
