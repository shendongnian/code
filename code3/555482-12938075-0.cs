      void dataRepeater_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {           
            var Combo = (ComboBox)e.DataRepeaterItem.Controls.Find("comboBox1", false)[0];
            Combo.DataSource = System.Enum.GetValues(typeof(ValueTypeAutoIncrementOverflowBehaviour));
        }
        void dataRepeater_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {            
            var Combo = (ComboBox)e.DataRepeaterItem.Controls["comboBox1"];
               
            if (ds.Tables["Preference"].Rows[e.DataRepeaterItem.ItemIndex]["OverflowBehaviour"].ToString() == "Exception")        
            {
                Combo.Text = "Exception";       
            }
            else
            {
                Combo.Text = "Wrap";      
            }
        }
      void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            
            var DataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
        
            //Update dataset
            if (ds.Tables["Preference"].Rows[DataRepeaterItem.ItemIndex]["OverflowBehaviour"].ToString() != combo.SelectedItem.ToString())
            {               
                ds.Tables["Preference"].Rows[DataRepeaterItem.ItemIndex]["OverflowBehaviour"] = combo.SelectedItem.ToString();                
            }
        }
