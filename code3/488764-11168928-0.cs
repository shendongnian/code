    String values = "";
    for (int i=0; i< cbl.Items.Count; i++)
    {
            if(cbl.Items[i].Selected)
            {
                    values += cbl.Items[i].Value + ",";
            }
    }
                           
    values = values.TrimEnd(',');
