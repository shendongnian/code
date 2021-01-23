        InitializeComponent();
        textBox1.Text = "Hello!"; <---- insert this here
        //populate listbox1
        listBox1.Items.Add("Arial");
        listBox1.Items.Add("Calibri");
        listBox1.Items.Add("Times New Roman");
        listBox1.Items.Add("Verdana");
        //populate listbox2
        listBox2.Items.Add("8");
        listBox2.Items.Add("10");
        listBox2.Items.Add("12");
        listBox2.Items.Add("14");
        this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
        listBox1.SelectedIndex = 0; // <--- set default selection for listBox1 
        this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
        listBox2.SelectedIndex = 0; // <--- set default selection for listBox2
    }
