    /// <summary>
    /// DataGridView column class for a check box column with cells that have an OnContentClick handler.
    /// </summary>
    public class DataGridViewEventCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        /// <summary>
        /// Empty constructor.  Pass through to base constructor
        /// </summary>
        public DataGridViewEventCheckBoxColumn()
            : base()
        { }
        /// <summary>
        /// Pass through to base constructor with threeState parameter
        /// </summary>
        /// <param name="threeState">True for three state check boxes, True, False, Indeterminate.</param>
        public DataGridViewEventCheckBoxColumn(bool threeState)
            : base(threeState)
        { }
        /// <summary>
        /// Constructor for setting the OnContentClick event handler for the cell template.
        /// Note that the handler will be called for all clicks, even if the DataGridView is ReadOnly.
        /// For the "new" state of the checkbox, use the EditedFormattedValue property of the cell.
        /// </summary>
        /// <param name="handler">Event handler for OnContentClick.</param>
        /// <param name="threeState">True for three state check boxes, True, False, Indeterminate.</param>
        public DataGridViewEventCheckBoxColumn(EventHandler<DataGridViewCellEventArgs> handler, bool threeState)
            : base(threeState)
        {
            CellTemplate = new DataGridViewEventCheckBoxCell(handler, threeState);
        }
    }
