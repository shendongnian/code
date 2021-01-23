    public interface IActionProvider
    {
        void SetVisibleGetter(ActionType type, Func<bool> getter);
        void SetEnabledGetter(ActionType type, Func<bool> getter);
    }
