    private bool _isDirty = false;
    public plainTextEditor() 
    {
        InitializeComponent();
        functionsProxy = new Functions();
        IsDirty = false;
    }
    /* Property added to flag Changed _isDirty event */
    public bool IsDirty
    {
        get { return _isDirty; }
        set
        {
            if (_isDirty != value)
            {
                _isDirty = value;
                OnIsDirtyChanged();
            }
        }
    }
    private void OnIsDirtyChanged()
    {
        if (_isDirty == true)
        {
            //textBox1.BackColor = Color.LightCoral;
            this.Text += "*";
        }
        else
        {
            this.Text = "Text Editor";
            //textBox1.BackColor = SystemColors.Window;
        }
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string newtext = textBox1.Text;
        if (currentText != newtext)
        {
            // This solves the problem of initial text being tagged as changed text
            if (currentText == "")
            {
                //textBox1.BackColor = SystemColors.Window;
                IsDirty = false;
            }
            else
            {
                IsDirty = true;
            }
            currentText = newtext;
        }
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        functionsProxy.doSave(textBox1.Text);
        IsDirty = false;
    }
