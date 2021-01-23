     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           var cbxMember = comboBox1.Items[comboBox1.SelectedIndex] as cbxItem;
          
          if (cbxMember != null) // safety check
           {
           var value = cbxMember.id; 
           }
        }
