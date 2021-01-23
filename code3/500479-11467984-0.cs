    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e) {
      if (e.Item is GridDataItem) {
        LinkButton link = (LinkButton )gridDataItem["ContentTitle"].Controls[0];
        link.ForeColor = System.Drawing.Color.Navy;
        link.ToolTip = Common.grdTextCell(gridDataItem["ContentSummaryDescr"].Text);
        link.NavigateUrl = "~/SomePath/" + gridDataItem["ContentName"].Text;
        link.Target = "_blank";
        link.Click += dummyBtn_Click;
      }
    }
    
    protected void dummyBtn_Click(object sender, EventArgs e) {
    }
