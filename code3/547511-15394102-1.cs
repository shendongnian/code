        private void lst_REQ_LIST_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst_REQ_LIST.SelectedValue == null) { return; }
            _selection_changed();
            bln_CHANGING_REQ = false;
        }
        private void _selection_changed()
        {
            string sGUID = lst_REQ_LIST.SelectedValue.ToString().ToUpper();
            req_guid = new Guid(sGUID);
            quote_guid = new Guid("{00000000-0000-0000-0000-000000000000}");
            bln_CHANGING_REQ = true;
            _load_data();
        }
        private void dg_VQ_TABLE_VIEW_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            if (bln_CHANGING_REQ) { return; }
            int rHANDLE = dg_VQ_TABLE_VIEW.FocusedRowHandle;
            //if (rHANDLE == dg_VQ_DTL_TABLE_VIEW.NewItemRowData.RowHandle.Value) { return; }
            _sync_child(rHANDLE);
        }
