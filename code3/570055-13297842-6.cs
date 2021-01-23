    private void comboBox_SelectedValueChanged(object sender, EventArgs e){
       foreach(ComboBox cb in comboBoxes){
          //Here listItems is a list of elements you added firstly to the comboboxes
          if(cb.Items.Count < listItems.Count)
             foreach(object item in listItems){ 
                 if(!cb.Items.Contains(item))
                   cb.Items.Add(item);
             }
          }
       }
       
       //Remove the selected items in all the comboboxes
       ComboBox comboBox = (ComboBox)sender;
       if(comboBox.SelectedItem != null){
          for(int i = 0; i < comboBoxes.Count; i++){
             for(int j = 0; j < comboBoxes.Count; j++){
                if(comboBoxes[j].SelectedItem != null && comboBoxes[j].Contains(comboBoxes[j].SelectedItem))
                  comboBoxes[i].Items.Remove(comboBoxes[j].SelectedItem);
             }
          }
       }
    }
