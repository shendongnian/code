    protected void TreeList_HtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
    {
        decimal budget = (decimal) e.GetValue("Budget");
        if ("EditColumn".Equals(e.Column.FieldName) && <your ClientID condition>)
        {
            ASPxButton button = (ASPxButton) treeList.FindDataCellTemplateControl(e.NodeKey, e.Column, "btnSample");
            if (button != null)
                button.Visible = false;
        }
    }
