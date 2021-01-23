    for (int i = 0; i <= CheckBoxList2.Items.Count - 1; i++)
            {
                if (CheckBoxList2.Items[i].Selected)
                {
                    CheckBoxList4.Items.Add(CheckBoxList2.Items[i].ToString().Trim());
                    
                }
            }
    foreach (ListItem item in CheckBoxList4.Items)
            {
                if (!CheckBoxList3.Items.Contains(item))
                {
                    CheckBoxList3.Items.Add(item);
                }
            }
