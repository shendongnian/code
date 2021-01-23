    // This would need to be in a top-level non-generic class
    public static T GetControlByAccessible<T>(this Control wrapper,
        string description, string name) where T : Control
    {
        return wrapper.Controls
                      .OfType<T>()
                      .FirstOrDefault(c => c.AccessibleDescription == description &&
                                           c.AccessibleName == name);
    }
