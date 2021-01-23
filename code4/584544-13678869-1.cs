    SetEnabled(controlCollection, false);
    await Task.Run(...);
    SetEnabled(controlCollection, true);
    ...
    private static void SetEnabled(IEnumerable<Control> controls, bool enabled)
    {
        foreach (var control in controls)
        {
            control.Enabled = enabled;
        }
    }
