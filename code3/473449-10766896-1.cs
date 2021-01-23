    private static Form1 _frm1;
    public void GetInstance(Form1 Frm1)
    {
        this._frm1 = Frm1;
    }
    
    private void Button2_Click_Close(args...)
    {
       _frm1.PassBack(this.TextBox2.Text);
       this.Close();
    }
