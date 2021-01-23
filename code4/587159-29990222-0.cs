        List<int> longestSequence = new List<int>();
        List<int> temp = new List<int>();
        int count = 0;
        int counter = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int nextElement = i+1;
            count = 0;
            temp.Clear();
            temp.Add(arr[i]);
            while (arr[i] == arr[nextElement])
            {
                temp.Add(arr[nextElement]);
                nextElement++;
                count++;
            }
            if (count > counter)
            {
                longestSequence.Clear();
                counter = count;
                for (int k = 0; k < temp.Count; k++)
                {
                    longestSequence.Add(temp[k]);
                }
            }
        }
        Console.WriteLine();
        foreach (int element in longestSequence)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
