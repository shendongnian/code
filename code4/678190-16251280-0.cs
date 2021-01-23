    private static readonly Random Rnd = new Random();
    
    static void Main(string[] args)
    {
        var loto = new int[7];
    
        for (int f = 0; f <= 6; f++)
        {
            var randomValue = GetRandomNumberNotInArr(loto);
            Console.WriteLine(randomValue);
            loto[f] = randomValue;
        }
        Console.Read();
    }
            
    private static int GetRandomNumberNotInArr(int[] arr)
    {
        var next = Rnd.Next(1, 50);
        return !arr.Contains(next) ? next : GetRandomNumberNotInArr(arr);
    }     
