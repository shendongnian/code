    Form1 form;
    public AddContact(Form1 f)
    {
        InitializeComponent();
        form = f;
    }
    private void btn_add_Click(object sender, EventArgs e)
    {
        if (textBox1.Text == string.Empty)
        {
            MessageBox.Show("No input has been given.");
        }
        else
        {
            string s = textBox1.Text;
            form.list_names.Items.Add(s);
            textBox1.Text = "";
        }
    }
