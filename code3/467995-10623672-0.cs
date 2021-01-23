    private Form1 _parentForm;
    public Form2(Form1 parentForm) : this()
    {
        _parentForm = parentForm;
    }
    
    public Form2()
    {
        InitializeComponents();
    }
    private void Form2_Load(object sender, EventArgs e)
    {
        richTextBox1.Font = new Font("Times New Roman", 12f, FontStyle.Regular); 
        dropdown(); 
        if(_parentForm != null)
            comboBox1.SelectedIndex = _parentForm.SelectedComboIndex; 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; 
    }
