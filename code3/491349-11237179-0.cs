    int n = 10;
    int[] numbers = (from sn in System.Text.RegularExpressions.Regex.Split(inputText.Text, @"\s*,\s*") select int.Parse(sn)).ToArray();
    int max = numbers.Max();
    int min = numbers.Min();
    //int max = numbers[0];
    //int min = numbers[0];
    //for(int i = 1; i < n; i++)
    //{
    //    if(max < numbers[i])
    //    {
    //        max = numbers[i];
    //    }
    //    if(min > numbers[i])
    //    {
    //        min = numbers[i];
    //    }
    //}
