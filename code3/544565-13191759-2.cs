    // fire cell edit event on single click
    objectListView1.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
    objectListView1.CellEditStarting += ObjectListView1OnCellEditStarting;
    // enable cell edit and always set cell text to "Delete"
    deleteColumn.IsEditable = true;
    deleteColumn.AspectGetter = delegate {
        return "Delete";
    };
