    protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (Wizard1.ActiveStep == Step1)
        {
            IEnumerable<RadioButton> controls = FindControls<RadioButton>(Step1);
            controls.ToList().ForEach(c => c.Enabled = false);
        }
    }
    IEnumerable<T> FindControls<T>(Control parent) where T : Control
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(T)) yield return (T)c;
            foreach (var subControl in FindControls<T>(c))
                yield return subControl;
        }
    }
