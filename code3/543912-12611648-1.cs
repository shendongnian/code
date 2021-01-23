    private List<Form> subForms;
    private bool minimized = false;
    public TopForm()
    {
        InitializeComponent();
        subForms = new List<Form>();
        subForms.Add(new SubForm(1));
        subForms.Add(new SubForm(2));
        subForms.Add(new SubForm(3));
        subForms.Add(new SubForm(4));
        subForms.Add(new SubForm(5));
        foreach (Form f in subForms)
        {
            f.Show();
        }
        BringToFront();
        Resize += OnResize;
    }
    /// <summary>
    /// Detects a resize event and handles it according to window state.
    /// </summary>
    /// <param name="sender">Top form</param>
    /// <param name="args">Unused</param>
    private void OnResize(object sender, EventArgs args)
    {
        switch (WindowState)
        {
        case FormWindowState.Normal:
            if (minimized)
            {
                minimized = false;
                OnRestore();
            }
            break;
        case FormWindowState.Minimized:
            minimized = true;
            OnMinimize();
            break;
        }
    }
    /// <summary>
    /// Minimize all sub forms
    /// </summary>
    public void OnMinimize()
    {
        foreach (Form form in subForms)
        {
            form.WindowState = FormWindowState.Minimized;
        }
    }
    /// <summary>
    /// Restore all forms and bring them to the front, with this main form on top.
    /// </summary>
    public void OnRestore()
    {
        foreach (Form form in subForms)
        {
            form.WindowState = FormWindowState.Normal;
            form.BringToFront();
        }
        BringToFront();
    }
