    protected void grvTest_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
            {
                if (e.RowType != GridViewRowType.Data) return;
     
                ASPxLabel label = grvTest.FindRowCellTemplateControl(e.VisibleIndex, null,
                "lblRowID") as ASPxLabel;
                label.Text = (e.VisibleIndex + 1).ToString();
            }
