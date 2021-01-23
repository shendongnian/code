    string colors = "Yellow,Brown";
            string[] col = colors.Split(',');
            foreach (ListItem lst in CheckBoxList1.Items)
            {
                for (int i = 0; i <= col.Length-1; i++)
                {
                    if (lst.Text == col[i])
                    {
                        lst.Selected = true;
                        break;
                    }
                }
            }
