    int i = 0;
    List<int> list = new List<int>();
    while (i < myNumber.Length)
    {
        if (i < myNumber.Length - 1 && int.Parse(myNumber[i + 1].ToString()) == 0)
        {
            list.Add(int.Parse(myNumber[i].ToString()) * 10);
            i += 2;
        }
        else
        {
            list.Add(int.Parse(myNumber[i].ToString()));
            i++;
        }  
    }
     
    return list.ToArray();
