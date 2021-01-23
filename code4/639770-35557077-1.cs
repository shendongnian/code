    private static IEnumerable<Control> AllSubControls(Control control)
        => Enumerable.Repeat(control, 1)
           .Union(control.Controls.OfType<Control>()
                                  .SelectMany(AllSubControls)
                 );
