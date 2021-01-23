    if (e.Item is GridDataItem) {
	    GridDataItem item = (GridDataItem)e.Item;
    	item["A"].Text = item["A"].Text + " /<br/>" + item["B"].Text;
	    Literal lit = new Literal();
    	lit.Text = " /<br/>" + item["D"].Text;
	    item["C"].Controls.Add( lit );
    }
