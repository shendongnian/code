    int[] array =  {5, 6, 2, 4};
    int num;
    if (Int32.TryParse(string.Join("", array), out num))
    {
        //success - handle the number
    }
    else
    {
        //failed - too many digits in the array
    }
