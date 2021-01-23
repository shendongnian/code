    static void OnTimer(object obj)
    {
        State state = obj as State;
        if (state == null)
            return;
    
        if (String.IsNullOrEmpty(state.Value))
            return;
        Console.WriteLine(state.Value);
        state.Value = null; // consider reseting state object 
    }
