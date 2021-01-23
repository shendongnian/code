    private static IEnumerable<Labels> FindAllLabels(Control container)
    {
        foreach (Control ctl in container.Controls)
        {
            var lbl = ctl as Label;
            if (lbl != null)
            {
                yield return ctl;
            }
            else if (ctl.HasChildren)
            {
                foreach (var innerResult in FindAllLabels(ctl))
                    yield return innerResult;
            }
        }
    }
    // now call the method like this if you want to change a property on the label
    foreach (var label in FindAllLabels(theForm))
        label.BackgroundColor = Color.White;
    // or like this (note the .ToList()) if you want to move the labels around:
    foreach (var label in FindAllLabels(theForm).ToList())
        label.Parent = someOtherControl;
    
