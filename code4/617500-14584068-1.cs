    private IDictionary<ActionType, Func<bool>> isActionVisible = new Dictionary<ActionType, Func<bool>> {
        { ActionType.Cacel, AlwaysFalse }
        { ActionType.Send, AlwaysFalse },
        ...
    };
    public void SetVisibleGetter(ActionType type, Func<bool> getter)
    {
        this.isActionVisible[type] = getter ?? this.isActionVisible[type];
    }
    ...
