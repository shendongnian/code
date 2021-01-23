    Dictionary<string, string[]> models = new Dictionary<string, string[]>();
    public Form1()
    {
        InitializeComponent();
    
        //initializing combobox1
        comboBox1.Items.Add("Select Company");
        comboBox1.Items.Add("HTC");
        comboBox1.Items.Add("Nokia");
        comboBox1.Items.Add("Sony");
        //select the selected index of combobox1
        comboBox1.SelectedIndex = 0;
    
        //initializing model list for each brand
        models["Sony"] = new string[] { "Xperia S", "Xperia U", "Xperia P" };
        models["HTC"] = new string[] { "WildFire", "Desire HD" };
        models["Nokia"] = new string[] { "N97", "N97 Mini" };
    }
    
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBox2.Items.Clear();
    
        if (comboBox1.SelectedIndex > -1)
        {
            string brand = comboBox1.SelectedItem.ToString();
            if(brand != "" && comboBox1.SelectedIndex > 0)
                foreach (string model in models[brand])
                    comboBox2.Items.Add(model);
        }
    }
