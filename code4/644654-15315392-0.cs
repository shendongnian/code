internal sealed class HandleCollector
{
    private static HandleChangeEventHandler HandleAddedField;
    internal static event HandleChangeEventHandler HandleAdded
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        add
        {
            HandleCollector.HandleAddedField = (HandleChangeEventHandler)Delegate.Combine(HandleCollector.HandleAddedField, value);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        remove
        {
            HandleCollector.HandleAddedField = (HandleChangeEventHandler)Delegate.Remove(HandleCollector.HandleAddedField, value);
        }
    }
}
