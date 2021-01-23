    int[] Histogram = new int[10];
    foreach(pixel p in bitmap)
    {
        histogram[p.color]++;
    }
    Array.Sort(Histogram);
    Console.WriteLine(Histogram[0]);
    Console.WriteLine(Histogram[1]);
    Console.WriteLine(Histogram[2]);
