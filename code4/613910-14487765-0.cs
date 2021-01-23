    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {    
            serialPort1.PortName = (string)comboBox1.SelectedValue;
        }
        catch (Exception ex) { 
            MessageBox.Show(ex.Message);
        }
    }
