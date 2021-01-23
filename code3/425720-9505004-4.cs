    public MyForm()
    {
        InitializeComponent();
        var myDelegate = new EventHandler(txt_TextChanged);
        foreach (var ctrl in this.Controls)
        {
            var txtBox = ctrl as TextBox;
            if (txtBox != null)
                txtBox.TextChanged += myDelegate;
        }
    }
