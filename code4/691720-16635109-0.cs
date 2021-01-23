    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    		{
    
    			for (int i = 0; i < comboBox2.Items.Count; i++)
    			{
    				if (comboBox2.Items[i] == comboBox1.SelectedItem)
    				{
    					comboBox2.Items.Remove(comboBox2.Items[i]);
    
    					i--;
    				}
    			}
    		}
