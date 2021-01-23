    function setSelectedRowId(RowId){
        	document.getElementById("txtRowId").value = RowId; }
    
        private void ObjList_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
           if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.SelectedItem)
           {
              e.Item.Attributes.Add("onclick", "setSelectedRowId('" + e.Item.Cells[0].Text + "');
           }
