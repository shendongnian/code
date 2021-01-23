    /// <summary>
    /// DataGridView cell class for check box cells with a OnContentClick event handler.
    /// </summary>
    public class DataGridViewEventCheckBoxCell : DataGridViewCheckBoxCell
    {
        /// <summary>
        /// Event handler for OnContentClick event.
        /// </summary>
        protected EventHandler<DataGridViewCellEventArgs> ContentClickEventHandler { get; set; }
        /// <summary>
        /// Empty constructor. Required. Used by Clone mechanism
        /// </summary>
        public DataGridViewEventCheckBoxCell()
            : base()
        { }
        /// <summary>
        /// Pass through constructor for threeState parameter.
        /// </summary>
        /// <param name="threeState">True for three state check boxes, True, False, Indeterminate.</param>
        public DataGridViewEventCheckBoxCell(bool threeState)
            : base(threeState)
        { }
        /// <summary>
        /// Constructor to set the OnContentClick event handler.  
        /// Signature for handler should be (object sender, DataGridViewCellEventArgs e)
        /// The sender will be the DataGridViewCell that is clicked.
        /// </summary>
        /// <param name="handler">Handler for OnContentClick event</param>
        /// <param name="threeState">True for three state check boxes, True, False, Indeterminate.</param>
        public DataGridViewEventCheckBoxCell(EventHandler<DataGridViewCellEventArgs> handler, bool threeState)
            : base(threeState)
        {
            ContentClickEventHandler = handler;
        }
        /// <summary>
        /// Clone method override.  Required so CheckEventHandler property is cloned.
        /// Individual DataGridViewCells are cloned from the DataGridViewColumn.CellTemplate
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            DataGridViewEventCheckBoxCell clone = (DataGridViewEventCheckBoxCell)base.Clone();
            clone.ContentClickEventHandler = ContentClickEventHandler;
            return clone;
        }
        /// <summary>
        /// Override implementing OnContentClick event propagation 
        /// </summary>
        /// <param name="e">Event arg object, which contains row and column indexes.</param>
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);
            if (ContentClickEventHandler != null)
                ContentClickEventHandler(this, e);
        }
        /// <summary>
        /// Override implementing OnContentDoubleClick event propagation 
        /// Required so fast clicks are handled properly.
        /// </summary>
        /// <param name="e">Event arg object, which contains row and column indexes.</param>
        protected override void OnContentDoubleClick(DataGridViewCellEventArgs e)
        {
            base.OnContentDoubleClick(e);
            if (ContentClickEventHandler != null)
                ContentClickEventHandler(this, e);
        }
    }
