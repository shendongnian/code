    public string ID2
    {
        get { return textBox1.Text; }
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var textBoxContent = this.textBox1.Text;
        var parent = this.Parent as Form1;
        parent.ID2 = ID2;  
    }
    
