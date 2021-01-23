    public IEnumerable<Control> AllControls(Control container)
    {
        foreach (Control control in container.Controls)
        {
            yield return control;
            foreach (var innerControl in AllControls(control))
                yield return innerControl;
        }
    }
