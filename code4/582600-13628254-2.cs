    string pageNos = "5,6,7,9,10,11,12,15,16";
    string result=string.Empty;
    string[] arr1 = pageNos.Split(',');
    int[] arr = new int[arr1.Length];
    for (int x = 0; x < arr1.Length; x++) // Convert string array to integer array
    {
        arr[x] = Convert.ToInt32(arr1[x].ToString());
    }
    StringBuilder sb = new StringBuilder();
    bool hyphenOpen = false;
    for (int i = 0; i < arr.Length - 1; i++)
    {
        if (arr[i] + 1 == arr[i+1])
        {
            if (!hyphenOpen)
            {
                hyphenOpen = true;
                sb.Append(arr[i] + "-");
	        }
	    }
        else
        {
			hyphenOpen = false;
			sb.Append(arr[i] + ",");
		}
	}
	sb.Append(arr[arr.Length-1]);
	Console.WriteLine(sb.ToString());
