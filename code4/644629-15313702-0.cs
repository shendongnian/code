    public static void Main(string[] args)
    {
        Task.Factory.StartNew(Calculate).ContinueWith(task =>
                                                          {
                                                              Console.WriteLine("Finished!");
                                                          });
        Console.WriteLine("Press ENTER to close...");
        Console.ReadLine();
    }
