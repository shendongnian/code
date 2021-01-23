    CheckBoxList cbl = (CheckBoxList)FindControl("CBL_categ");
    if (cbl != null)
    {
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.Items[i].Selected)
                {
                    catn = cbl.Items[i].Value;
                 }
             }
     }
