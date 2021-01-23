    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
            {
                if (e.CommandName == "Select")
                {
                    ((TextBox)e.Item.FindControl("Textboxname")).Text = ((Label)e.Item.FindControl("LabelName")).Text;
                }
            }
