    private void cmbBox_SelectedIndexChanged(object sender, EventArgs e)
    {
         RecalcTotal();
    }
    private void RecalcTotal()
    {
         int counter = 0;
         if(cmbBox1.SelectedIndex > 0)
             counter++;
         if(cmbBox2.SelectedIndex > 0)
             counter++;
         if(cmbBox3.SelectedIndex > 0)
             counter++;
         txtBox1.Text = string.Empty;
         if(counter > 0)
             txtBox1.Text = counter.ToString();
    }
