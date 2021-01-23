    private void validateComboBox(object sender, EventArgs e)
    {
      ComboBox thisCB = sender as ComboBox;
      if (thisCB.Text != "")
      {
           foreach (ComboBox cb in toolParameterComboBoxes)
           {
               if (thisCB.Name != cb.Name && thisCB.Text == cb.Text && thisCB.Text != "" && cb.Text != "")
               {
                   MessageBox.Show("You cannot duplicate tool parameters." + "\r\n" + "\r\n" 
                                + "That option has been selected in " + cb.Name.Replace("comboBox", ""), "Error");
                            thisCB.SelectedIndex = 0;
                            break;
               }
            }
      }
    }
