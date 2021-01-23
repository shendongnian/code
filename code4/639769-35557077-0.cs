    private static List<Control> AllSubControls(Control control)
    {
        var list = control.Controls.OfType<Control>().ToList();
        var deep = list.Where(o => o.Controls.Count > 0).SelectMany(AllSubControls).ToList();
        list.AddRange(deep);
        return list;
    }
