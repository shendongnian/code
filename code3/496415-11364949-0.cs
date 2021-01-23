    public static bool Count(int CountToWhat, Action<int> reportProgress) {
    for (int i = 0; i < CountToWhat; i++) {
        var progress = CountToWhat / i; 
        reportProgress(progress);
        Console.WriteLine(i.ToString());
    }
