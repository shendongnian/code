    // Assuming some grid type TDataGrid and some column building type TColumnBuilder
    public TDataGrid Columns(Action<TColumnBuilder> applyColumns)
    {
        // Ask the user what they'd like to do with our columns
        TColumnBuilder placeholder = new TColumnBuilder();
        applyColumns(placeholder);
        // do something with what we've learned
        // this.columns = placeholder.CreateColumns();
    }
