    private void button1_Click(object sender, EventArgs e)
    {
        string test = "[one]\t\t\t[two]\t\t\t";
        string[] testArr = test.Split(new char[] { '\t' }, StringSplitOptions.None);
        int maxLength = maxNumberOfRepeatingElements(testArr, string.Empty);
        testArr = RepeatingElementItemsSameLength(testArr, string.Empty, maxLength);
    }
    private int maxNumberOfRepeatingElements(string[] arr,string repeatingElement)
    {
    int count = 0;
    int maxLength = 0;
    foreach(var s in arr)
    {
        if (s == repeatingElement)
        {
            count++; 
            if (count > maxLength) maxLength = count;
        }
        else
        {
            count = 0;
        }
    }
    return maxLength;
    }
    
    private string[] RepeatingElementItemsSameLength(string[] arr,string subArrayItem, int maxLength)
    {
    int count = 0;
    var subArrItemsOfEqualLength = new List<string>();
    
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == subArrayItem)
        {
            count++;
            subArrItemsOfEqualLength.Add(arr[i]);
        }
        else if (arr[i] != subArrayItem)
        {
            if (i != 0 && count < maxLength)
            {
                do
                {
                    subArrItemsOfEqualLength.Add(subArrayItem);
                    count++;
                } while (count != maxLength);
            }
            count=0;
            subArrItemsOfEqualLength.Add(arr[i]);
        }
    }
    return subArrItemsOfEqualLength.ToArray();
    }
