    protected void TreeList_HtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
    {
        int empId = (int) e.GetValue("EmpID");
        if ("EditColumn".Equals(e.Column.FieldName) && empId == 1)
        {
            ASPxButton button = (ASPxButton) treeList.FindDataCellTemplateControl(e.NodeKey, e.Column, "btnSample");
            if (button != null)
                button.Visible = false;
        }
    }
