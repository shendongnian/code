    foreach(int a in Numbers)
    {
       // 1. I've gotten rid of the no-op lambda. 
       // 2. Note that Max works by enumerating the entire source.
       var max = Numbers.Max();
       if(a == max)
         Console.WriteLine(a);
    }
