    public void listBox1_SelectedValueChanged(object sender, EventArgs e)
      {
        if(listBox1.SelectedIndex > -1)
        {
          Prime_Broker broker = (Prime_Broker)listBox1.SelectedItem;
          Margin2 mrg;
          if(myDictionary.TryGetValue(broker.Name, mrg)
          {
            textBox1.Text = String.Format("{0}, {1}, {2}", 
                               mrg.Maintenance_margin,
                               mrg.Initial_margin,
                               mrg.Commission_fees_percentage);
          }
        }
      }
