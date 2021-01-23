    public static IDisposable SubscribeAndHandle(this IObservable<KeyEventArgs> input, Action<Keys> action)
    {
        return input.Do(e => e.Handled = true)
                    .Select(e => e.KeyCode)
                    .Subscribe(e => action(e));
    }
