    int sum=0, input;
    do
    {
        input = Convert.ToInt32(Console.ReadLine());
        sum += input;
    }
    while(input != 0);
    
    Console.WriteLine(sum);
    Console.ReadLine();
