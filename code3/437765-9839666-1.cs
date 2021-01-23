        protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedItems == null || RadGrid1.SelectedItems.Count == 0)
                return;
            var dataItem = RadGrid1.SelectedItems[0] as GridDataItem;
            if (dataItem != null)
            {
                var myId = dataItem.GetDataKeyValue("id").ToString();
                var hiddenfield1 = dataItem.GetDataKeyValue("HiddenVal1").ToString();
                //do stuff
            }
        }
