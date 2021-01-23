     foreach (ListItem li in CheckBoxList1.Items)
        {
            if (li.Selected)
            {
                if (!CheckBoxList2.Items.Contains(li))
                {
                    CheckBoxList2.Items.Add(li);  
                }
            }
        }
