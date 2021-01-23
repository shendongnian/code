    int rack = 0; //Initialize rack as an int of value 0
    private void button2_Click(object sender, EventArgs e)
    {    
        //MessageBox.Show(rack.ToString());    
    }
    
    private void label10_Click(object sender, EventArgs e)
    {
        rack = 11; //Set rack to 11
        button2_Click(sender, e); //Call button2_Click
    }
