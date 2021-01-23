    public FormConsole MyForm
    {
        get { return _myForm; }
        set { _myForm = value; }
    }
    // and/or...
    public ListBoxForm(FormConsole myForm) 
    {
        MyForm = myForm;
    }
