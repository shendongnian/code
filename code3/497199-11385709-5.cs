    private void UpdateFont()
    {
        if (listBox1.SelectedIndex == -1 || listBox2.SelectedIndex == -1)
            return;  // selection not complete yet, so do nothing
    
        string typeface = listBox1.SelectedItem.ToString();
        float size = Convert.ToSingle(listBox2.SelectedItem.ToString());
    
        textBox1.Font = new Font(typeface, size);
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)  
    {  
        UpdateFont();
    }  
  
    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)  
    {  
        UpdateFont();
    }  
    
