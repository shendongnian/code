     int[] a = new int[5];
     int minpos;
     int maxpos;
     int min = Int32.MaxValue;
     int max = a[0];
     int temp = 0;
     for (int i = 0; i < 5; i++)
     {
        Console.WriteLine(" Enter number " + (i + 1));
        Int32.TryParse(Console.ReadLine(), out temp);
        a[i] = temp;
        //Decision Making Logic 
        if (min > temp)
        {
            min = temp;
            minpos = i;
        }
        if (max < temp)
        {
            max = temp;
            maxpos = i;
        }
    }
