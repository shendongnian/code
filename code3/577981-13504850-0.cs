    public static void TasteAll<Mode>(Action<Mode> Make)
    {
            foreach (Mode mode in Enum.GetValues(typeof(Mode)))
            {
                Mode localMode = mode;
                Task.Factory.StartNew(() => Make(localMode) );
                //Make(mode); //<-- Works Fine with normal call
            }
        Console.ReadLine();
    }
