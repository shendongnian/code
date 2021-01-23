     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
     {
          String genderString = ((DataRowView)comboBox1.SelectedItem).Row["gender"].ToString();
          
          if (!String.IsNullOrEmpty(genderString))
          {
               comboBox2.SelectedItem = ((DataRowView)comboBox1.SelectedItem).Row["gender"].ToString(); //the value of gender in database is put in the combobox2
          }
          else
          {
               comboBox2.SelectedIndex = -1;
          }
     }
