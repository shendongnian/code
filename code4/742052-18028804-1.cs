    private void txtResults_KeyDown(object sender, KeyEventArgs e)
    {
      string[] words= ((TextBox)sender).Text.Split(' ');
      string s = sampleWord.Text = words[words.Length - 1];
      if (e.KeyCode == Keys.OemPeriod)
      {
        ShowPopUpList(s);//Show your ListBox without needing to focus it.        
      }
      if(lst.Visible){
        if(e.KeyCode == Keys.Down){      
          lst.SelectedIndex = (lst.SelectedIndex + 1) % lst.Items.Count;
        }
        else if (e.KeyCode == Keys.Up){
          lst.SelectedIndex = lst.SelectedIndex == 0 ? lst.Items.Count - 1 : lst.SelectedIndex - 1
        }
        else if (e.KeyCode == Keys.Enter){//Add the selected Item
            //Add the selected Item here not in the KeyDown event handler of your ListBox
            //.........
            //.........
            //Your TextBox may not need to handle the Enter, so just suppress it after adding the selected item
            e.Handled = true;
        }
        else
        {
          lst.Hide();
        }
      }
    }
