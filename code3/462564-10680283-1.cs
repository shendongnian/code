        /// <summary>
        /// Adds or removes cancel event.
        /// </summary>
        public event CancelEventHandler Cancel;
        /// <summary>
        /// Adds or removes progress changed event.
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        /// <summary>
        /// Raises progress changed event.
        /// </summary>
        /// <param name="e">
        /// <see cref="ProgressChangedEventArgs"/> params.
        /// </param>
        protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
        {
            EventHandler<ProgressChangedEventArgs> handler = this.ProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// Raises cancel event.
        /// </summary>
        /// <param name="e">
        /// </param>
        protected virtual void OnCancel(CancelEventArgs e)
        {
            CancelEventHandler handler = this.Cancel;
            if (handler != null)
            {
                handler(this, e);
            }
        }
