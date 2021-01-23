    // repeater item
    foreach (Control cr in MyRepeater.Controls)
    {
        // controls within repeater item
        foreach (Control c in cr.Controls)
        {
            CheckBoxList chklst = c as CheckBoxList;
            if (chklst != null)
            {
                foreach (ListItem i in chklst.Items)
                {
                    string valueToUpdate = i.Value;
                    string textToUpdate = i.Text;
                    bool checkedToUpdate = i.Selected;
                    // Do update
                }
            }
        }
    }
