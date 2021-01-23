    BindingSource bs1 = new BindingSource();
    BindingSource bs2 = new BindingSource();
    bs2.Filter = "My Filter"; // Instead of setting filter on DataView, I had to set it on binding source.
    bs1.DataSource = new DataView(dt);
    bs2.DataSource = new DataView(dt);
    //bs2.DataSource = new DataView(dt, RowFilter: "My Filter", Sort: "", RowState: DataViewRowState.CurrentRows); // This does not work.
