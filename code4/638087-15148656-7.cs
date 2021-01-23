    private void button3_Click(object sender, EventArgs e)
    {        
          var busLogic = new BusLogic();
          busLogic.PopulateListBoxItems(textBox8.Text);          
          \\listBox1.Items.Clear();
          ListboxItems.DataSource = busLogic.ListboxItems;
    }
