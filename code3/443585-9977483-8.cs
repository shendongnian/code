    static void OnTimer(object obj)
    {
        State state = obj as State;
        if (state == null)
            return;        
        Console.WriteLine(state.Value);
    }
