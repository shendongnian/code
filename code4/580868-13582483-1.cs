    public Form1()
        {
            var combobox = new ComboBoxEx() { DropDownStyle = ComboBoxStyle.DropDownList };
            combobox.Items.Add("Item 1");
            combobox.Items.Add("Item 2");
            combobox.Items.Add("Item 3");
            this.Controls.Add(combobox);
            combobox.SelectedIndexChanged += OnIndexChanged;
            InitializeComponent();
        }
        private void OnIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Index changed");
        }
