    var text = String.Join(Environment.NewLine, 
                           FindControls<ComboBox>(this).Select(c => c.Text));
----
    IEnumerable<T> FindControls<T>(Control ctrl) where T : Control
    {
        foreach (Control c in ctrl.Controls)
        {
            if (c.GetType() == typeof(T)) yield return (T)c;
            foreach (var subC in FindControls<T>(c))
                yield return subC;
        }
    }
