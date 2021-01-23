    private static readonly Dictionary<int, Action<SendParameters>> Actions = 
        new Dictionary<int, Action<SendParameters>>
    {
        { 1, MoveUnit },
        { 2, AttackUnit }
    };
    ...
    static void HandleRequest(Request request)
    {
        Action<SendParameters> action;
        if (Actions.TryGetValue(request.OperationCode, out action))
        {
            action(request.Parameters);
        }
    }
    static void MoveUnit(SendParameters parameters)
    {
    }
    static void AttackUnit(SendParameters parameters)
    {
    }
