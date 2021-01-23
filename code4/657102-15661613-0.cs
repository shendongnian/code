    private static IDictionary<string, Action> _actionsByCommand;
    
    static MyClass() {
        _actionsByCommand[ACK] = Acknowledge;
        _actionsByCommand[POLL] = Poll;
    }
    
    private static void Acknowledge() { }
    private static void Poll() { }
    
    static void Main() {
        string command = ...;
        _actionsByCommand[command]();
    }
