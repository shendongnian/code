    public static void DeshabilitarControles(Control control)
    {
        if (control.Parent != null)
        {
            Control padre = control.Parent;
            DeshabilitarControles(control, padre);
        }
    }
    private static void DeshabilitarControles(Control control, Control padre)
    {
        foreach (Control c in padre.Controls)
        {
            c.Enabled = c == control;
        }
        if (padre.Parent != null)
        {
            control = control.Parent;
            padre = padre.Parent;
            DeshabilitarControles(control, padre);
        }
    }
    public static void HabilitarControles(Control control)
    {
        if (control != null)
        {
            control.Enabled = true;
            HabilitarControles(control.Parent);
        }
    }
