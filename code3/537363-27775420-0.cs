     private void button1_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < chBoxListTables.Items.Count; i++)
                if (chBoxListTables.GetItemCheckState(i) == CheckState.Checked)
                {
                   txtBx.text += chBoxListTables.Items[i].ToString() + " \n"; 
                    
                }
        }
