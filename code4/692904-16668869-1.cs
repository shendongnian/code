    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
       ComboBox cbx = sender as ComboBox;
       if (cbx.Text == "OK")
       {
          cbx.ForeColor = Color.Black;
       }
       else
       {
          cbx.ForeColor = Color.Red;
       }
    }
