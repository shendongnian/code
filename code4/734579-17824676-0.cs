    public Form1()
    {
        InitializeComponent();
        HoolHandlers();
        LoadValues();
    }
    private void HoolHandlers()
    {
        comboBox1.SelectedIndexChanged += ComboBoxItemChanged;
        comboBox2.SelectedIndexChanged += ComboBoxItemChanged;
        comboBox3.SelectedIndexChanged += ComboBoxItemChanged;
    }
    private void LoadValues()
    {
        comboBox1.Items.Add("select radio...");
        comboBox1.Items.Add("value");
        comboBox2.Items.Add("select radio...");
        comboBox2.Items.Add("value");
        comboBox3.Items.Add("select radio...");
        comboBox3.Items.Add("value");
    }
    private void ComboBoxItemChanged(object sender, EventArgs eventArgs)
    {
        ComboBox combo = (ComboBox) sender;
        if (combo.SelectedItem == "value")
        {
            int tbValue;
            if (textBoxContainingValue.Text != "")
            {
                tbValue = int.Parse(textBoxContainingValue.Text);
                tbValue++;
            }
            else
            {
                tbValue = 1;
            }
            textBoxContainingValue.Text = tbValue.ToString();
        }
        else
        {
            textBoxContainingValue.Text = "";
        }
    }  
