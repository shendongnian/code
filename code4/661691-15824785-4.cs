        /// <summary>
        /// Gets the host view model.
        /// </summary>
        public IHasBottomPanel Host { get; private set; }
        /// Gets a value that determines what buttons appear in the bottom panel.
        /// </summary>
        public BottomPanelButtons Buttons { get; private set; }
        /// <summary>
        /// Creates a new ViewModel for a <see cref="BottomPanel"/> control.
        /// </summary>
        /// <param name="buttons">An enum that determines which buttons are shown.</param>
        /// <param name="host">An interface representing the ViewModel that will handle the commands.</param>
        public BottomPanelViewModel(BottomPanelButtons buttons, IHasBottomPanel host)
        {
            Buttons = buttons;
            Host = host;
        }
