    public Form1()
    {
        InitializeComponent();
        textBox1.Font = new Font(textBox1.Font, FontStyle.Italic); //Italic Font for textBox1
        comboBox1.Font = new Font(comboBox1.Font, FontStyle.Italic); //Italic Font for comboBox1
        SendMessage(textBox1.Handle, TB_SETCUEBANNER, 0, "Type Here..."); //Cue Banner for textBox1
        SendMessage(comboBox1.Handle, CB_SETCUEBANNER, 0, "Type Here..."); //Cue Banner for comboBox1
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (textBox1.Text != "")
        {
            textBox1.Font = new Font(textBox1.Font, FontStyle.Regular); //Regular Font for textBox1 when user types
        }
        else
        {
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic); //Italic Font for textBox1 when theres no text
        }
    }
