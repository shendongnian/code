    private static void Main(string[] args)
    {
        var rnd = new Random();
        var task = GetRandomNumber(rnd);
        while(!task.IsCompleted){
        System.Console.Write("Loading .");
        System.Console.Write(".");
        System.Console.Write("./n");
        }
    }
    private static Task GetRandomNumber(Random rnd)
    {
        return Task.Run(() =>
            {
                while (rnd.Next() != 0)
                {
                }
            });
    }
