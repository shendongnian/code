public void chkAssignee_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox selectBox = (CheckBox)sender;
        GridViewRow myRow = (GridViewRow)selectBox.Parent.Parent;  // the row
        GridView myGrid = (GridView)myRow.Parent.Parent; // the gridview
        string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
        GridViewRow rowSelect = (GridViewRow)selectBox.Parent.Parent;
        int a = rowSelect.RowIndex;
        ArrayList SelecterdRowIndices=new ArrayList();
        if(ViewState["SelectedRowIndices"]!=null)
        {
            SelecterdRowIndices=(ArrayList)ViewState["SelectedRowIndices"];
            bool flag=false;
            foreach (int i in SelecterdRowIndices)
            {
                if(i==Convert.ToInt32(ID))
                {
                    flag=true;
                    break;
                }   
            }
            if(!flag)
            {
                SelecterdRowIndices.Add(ID);
            }
        }  
        else
        {
             SelecterdRowIndices.Add(ID);
        }
        ViewState["SelectedRowIndices"] = SelecterdRowIndices;
    }
</Pre>
