    public static void AddCssClass(this WebControl control, params string[] args)
    {
        List<string> classes = control.CssClass.Split(' ').ToList<string>();
        List<string> classesToAdd = args.Where(x => !classes.Contains(x)).ToList<string>();
        classes.AddRange(classesToAdd);
        control.CssClass = String.Join(" ", classes);
    }
    public static void RemoveCssClass(this WebControl control, params string[] args)
    {
        List<string> classes = control.CssClass.Split(' ').ToList<string>();
        classes = classes.Where(x => !args.Contains(x)).ToList<string>();
        control.CssClass = String.Join(" ", classes);
    }
