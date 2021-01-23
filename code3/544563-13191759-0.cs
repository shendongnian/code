	// fire cell edit event on single click
	MyOlv.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
	this.MyOlv.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this._MyOlv_CellEditStarting);
	// enable cell edit and always set cell text to "Delete"
	deleteColumn.IsEditable = true;
	deleteColumn.AspectGetter = delegate(object rowObject) {
		return "Delete";
	};
