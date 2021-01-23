    public void listBox1_SelectedValueChanged(object sender, EventArgs e)
       {
          if(listBox1.SelectedIndex > -1)
          {
            broker = (Prime_Broker)listBox1.SelectedItem;
            // use your Dictionary.TryGetValue() to retrieve the
            // broker by name
          }
       
       }
