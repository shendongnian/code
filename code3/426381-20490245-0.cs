     string items = string.Empty;
            foreach (ListItem i in CheckBoxList1.Items)
            {
                if (i.Selected == true)
                {
                    items += i.Text + ",";
                }
            }
            Response.Write("selected items"+ items);
