    private void button2_Click(object sender, EventArgs e) {
    
        radioButton1.Text = Month[i].ToString();
        radioButton2.Text = Month[i].ToString();
        radioButton3.Text= Month[i].ToString();
    
        i = (i + 1) % 5;
    
    }
