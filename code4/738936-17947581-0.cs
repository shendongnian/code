    public static IEnumerable<Control> GetControls(ControlCollection controlCollection)
    {
        foreach (Control control in controlCollection)
        {
            yield return control;
            if (control.Controls == null || control.Controls.Count == 0)
                continue;
            foreach (var sub in GetControls(control.Controls))
            {
                yield return sub;
            }
        }
    }
