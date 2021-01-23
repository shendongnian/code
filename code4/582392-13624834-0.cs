{<pre><Code>`enter code here`
        CheckBox selectBox = (CheckBox)sender;<pre><Code>
        GridViewRow myRow = (GridViewRow)selectBox.Parent.Parent;  // the row
        GridView myGrid = (GridView)myRow.Parent.Parent; // the gridview
        string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
        GridViewRow rowSelect = (GridViewRow)selectBox.Parent.Parent;
        int a = rowSelect.RowIndex;
        ArrayList SelecterdRowIndices=new ArrayList();
        if(ViewState["SelectedRowIndices"]!=null)
        {
             ArrayList SelecterdRowIndices=(ArrayList)ViewState["SelectedRowIndices"];
             bool flag=false;
             foreach (int i in SelecterdRowIndices)
	     {
                 if(i==ID)
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
