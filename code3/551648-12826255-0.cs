    Stored details = new Stored();
    private void setBtn_Click(object sender, EventArgs e){          
        details.MyProperty = colourBx.Text;             
    }
    private void getBtn_Click(object sender, EventArgs e)
    {
        string Displaycolour;
        Displaycolour = details.MyProperty;
        colourBx.Text = Displaycolour;
    }
    private void clrBtn_Click(object sender, EventArgs e)
    {            
        colourBx.Clear();            
    }    
