    private String _selectedRadioText;
    
    public MyForm() { // your form's constructor
        InitializeComponent();
        radioButton1.CheckedChanged += RadioButtonCheckedChanged;
        radioButton2.CheckedChanged += RadioButtonCheckedChanged;
        radioButton3.CheckedChanged += RadioButtonCheckedChanged;
        // or even:
        // foreach(Control c in this.groupBox.Controls)
        //     if( c is RadioButton )
        //         ((RadioButton)c).CheckedChanged += RadioButtonCheckedChanged;
        
        // Initialize the field
        _selectedRadioText = radioButton1.Text;
    }
    
    private void RadioButtonCheckedChanged(Object sender, EventArgs e) {
        _selectedRadioText = ((RadioButton)sender).Text;
    }
    // then just concatenate the _selectedRadioText field into your string
