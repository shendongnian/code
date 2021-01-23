    /// <summary>
    /// Recursively lists all controls under a specified parent control.
    /// Child controls are listed before their parents.
    /// </summary>
    /// <param name="parent">The control for which all child controls are returned</param>
    /// <returns>Returns a sequence of all controls on the control or any of its children.</returns>
    public static IEnumerable<Control> AllControls(Control parent)
    {
        if (parent == null)
        {
            throw new ArgumentNullException("parent");
        }
        foreach (Control control in parent.Controls)
        {
            foreach (Control child in AllControls(control))
            {
                yield return child;
            }
            yield return control;
        }
    }
