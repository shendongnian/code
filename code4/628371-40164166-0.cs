        #region Events
        public delegate void AfterTreeCheckEventHandler(object sender/*, object rowmodel*/);
        /// <summary>
        /// Triggered when clicked main checkbox checked and all related too.
        /// </summary>
        [Category("ObjectListView"),
        Description("This event is triggered when clicked main checkbox checked and all related too.")]
        public event AfterTreeCheckEventHandler AfterTreeCheckAndRecalculate;
        #endregion
        #region OnEvents
        /// <summary>
        /// Tell the world when a cell has finished being edited.
        /// </summary>
        protected virtual void OnAfterTreeCheckAndRecalculate(/*CellEditEventArgs e*/)
        {
            if (this.AfterTreeCheckAndRecalculate != null)
                this.AfterTreeCheckAndRecalculate(this/*, e*/);
        }
        #endregion
