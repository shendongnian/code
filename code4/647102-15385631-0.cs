    if (selectionBox.SelectedItem != null)
    {
        chosenBox.Items.Add(selectionBox.SelectedItem);
        selectionBox.Items.Remove(selectionBox.SelectedItem);
        foreach (Module m in module)
        {
            if (m.Name.Equals(selectionBox.SelectedItem)
            {
                chosen.Add(m.Info);
                chosen.Add(m.Code);
                ...
                break;
            }
         }
         errorLabel.Text = "";
         moduleCount++;
         if (moduleCount >= 8)
         {
             isFull = true;
             errorLabel.Text = "You have selected 8 Modules please fill the fields and submit";
             selectionBox.Enabled = false;
         }
         else
         {
            errorLabel.Text = "Please select a module";
         }
     }
     numberChosen.Text = String.Format(moduleCount.ToString());
