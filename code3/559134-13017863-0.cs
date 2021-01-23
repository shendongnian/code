    protected void OnGridItemCommand(object sender, DataGridCommandEventArgs args) {
        if (args.Item.ItemIndex == -1) {
            return;
        }
        // PropertyName is fetched here
        object value = datagrid.DataKeys[args.Item.ItemIndex];
        switch (args.CommandName) {
            case "RemoveRow": {
               // use value
            }
            break;
        }
    }
