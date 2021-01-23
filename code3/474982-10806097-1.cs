    private static readonly Dictionary<int, Action<Foo, SendParameters>> Actions = 
        new Dictionary<int, Action<Foo, SendParameters>>
    {
        { 1, (foo, parameters) => foo.MoveUnit(parameters) },
        { 2, (foo, parameters) => foo.AttackUnit(parameters) }
    };
    private void MoveUnit(SendParameters parameters)
    {
    }
