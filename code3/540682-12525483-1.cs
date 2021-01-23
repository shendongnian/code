    private void button2_Click(object sender, EventArgs e) 
    { 
            string name = textBox1.Text; 
    		DataGridViewToExcel(name, dgvCostumers);
     
            MessageBox.Show("Excel file created , you can find the file c:\\my documents\\" + name + ".xls"); 
     
            textBox1.Text = ""; 
            textBox1.Visible = false; 
            button1.Visible = true; 
            label2.Visible = false; 
        } 
    } 
