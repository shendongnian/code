    protected void DDLInclusions_SelectedIndexChanged(object sender, EventArgs e)
    {
            string name = "";
            ListBox selectedValues = (ListBox)sender;
            GridViewRow row = (GridViewRow)selectedValues.NamingContainer;
            int a = row.RowIndex;
            foreach (GridViewRow rw in gvwRoomType.Rows)
            {
                if (rw.RowIndex == a)
                {
                    ListBox lstRoomInclusions = rw.FindControl("DDLInclusions") as ListBox;
                    for (int i = 0; i < lstRoomInclusions.Items.Count; i++)
                    {
                        if (lstRoomInclusions.Items[i].Selected)
                        {
                            name += lstRoomInclusions.Items[i].Text + ",";
                        }
                    }
                    TextBox txtInclusions = rw.FindControl("txtRoomInclusions") as TextBox;
                    txtInclusions.Text = name;
                }
            }
    }
