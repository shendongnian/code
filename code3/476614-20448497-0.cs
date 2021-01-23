    private void buttonPlus1_Click(object sender, EventArgs e)
    {
       try
       {
           int txtValue = Convert.ToInt32(textBox.Text) + 100;
           textBox.Text = txtValue.ToString();
       }
       catch(Exception ex)
       {
         MessageBox.Show(ex.Message.ToString());
       }
    }
