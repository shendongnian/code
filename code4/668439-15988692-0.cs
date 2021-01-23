    public Form1()
    {
        InitializeComponent();
        FiltreTbx.AddTextBoxFilter(tbxSigné,
                                   double.MinValue, double.MaxValue,
                                   @"[^\d\,\;\.\-]");
    }
