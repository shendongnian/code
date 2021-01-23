    public static void TasteAll<Mode>(Action<Mode> Make)
    {
            Parallel.ForEach(Enum.GetValues(typeof(Mode)), mode =>
            {
                Mode localMode = mode;
                Make(mode);
            });
        Console.ReadLine();
    }
