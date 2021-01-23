    // In a new Windows Forms Application, drop a GroupBox with a ComboBox and a CheckBox inside
    // Then drop a TextBox outside the ComboBox. Then copy-paste.
    // this goes somewhere in your project
    public static class handlerClass
    {
        public static string ControlChanged(Control whatChanged)
        {
            return whatChanged.Name;
        }
    }
    // And then you go like this in the Load event of the GroupBox container
    void Form1_Load(object sender, EventArgs args)
    {
        foreach (Control c in groupBox1.Controls)
        {
            if (c is ComboBox) 
                (c as ComboBox).SelectedValueChanged += (s, e) => { textBox1.Text = handlerClass.Handle(c); }; 
            if (c is CheckBox) 
                (c as CheckBox).CheckedChanged += (s, e) => { textBox1.Text = handlerClass.Handle(c); }; }
        }
    }
