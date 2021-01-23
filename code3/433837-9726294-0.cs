    public Form1() {
      InitializeComponent();
      radioButton1.Checked = true;
      radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
      radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
    }
    private void radioButton_CheckedChanged(object sender, EventArgs e) {
      RadioButton rb = (RadioButton)sender;
      if (rb.Checked)
        MessageBox.Show("User checked " + rb.Text);
    }
