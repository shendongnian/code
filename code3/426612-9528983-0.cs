             //here ArrayList contains the ids to match
             ArrayList a=new ArrayList();
             a.Add(201105);
             a.Add(201106);
             //loop through the items in the datalist
             for (int i = 0; i < DataList1.Items.Count;i++ )
             {
                 //check if the list contains the items 
                 if (a.Contains(Convert.ToInt32(DataList1.DataKeys[i])))
                 {
                     (DataList1.Items[i].FindControl("CheckBox1") as CheckBox).Checked = true;
                 }
             }
