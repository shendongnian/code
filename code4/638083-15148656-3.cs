    private void button3_Click(object sender, EventArgs e)
    {        
          var busLogic = new BusLogic();
          busLogic.PopulateListBoxItems();          
          \\listBox1.Items.Clear();
          ListboxItems.DaatSource = busLogic.ListboxItems;
    }
