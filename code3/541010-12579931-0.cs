    public static Form GetLastForm()
    {
        if (Form.ActiveForm != null && !(Form.ActiveForm is MsgBox))
            return Form.ActiveForm;
        var openForms = Application.OpenForms.Cast<Form>().Where(f => !(f is MsgBox));
        if (openForms.Count == 0)
            return null;
        foreach (var frame in new StackTrace().GetFrames())
        {
            Type type = frame.GetMethod().DeclaringType.BaseType;
            if (type != typeof(Form))
                continue;
            foreach (Form f in openForms)
            {
                if (f.GetType() == type)
                    return f;
            }
        }
        return null;
    }
