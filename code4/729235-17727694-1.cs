    public ChangeValues()
        {
            InitializeComponent();
            //dataGridView1.Dock = DockStyle.Fill;
            ChangeValues.ActiveForm.Activate();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChangeValues());
            Application.SetCompatibleTextRenderingDefault(false);
        }
    
    public void AddEntry(string attribute, string value)
        {
            Label lbl = new Label { Text = attribute, Dock = DockStyle.Top };
            lbl.Parent = splitContainer1.Panel1;//This is the same to splitContainer1.Panel1.Controls.Add(lbl);
            lbl.BringToFront();
            TextBox txt = new TextBox { Text = value, Dock = DockStyle.Top };
            txt.Parent = splitContainer1.Panel2;
            txt.BringToFront();
            lbl.Height = txt.Height;
        }
    
    private void ChangeValues_Load(object sender, EventArgs e)
        {
        }
