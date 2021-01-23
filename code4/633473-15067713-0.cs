    public class ObservableList<T> : ObservableCollection<T>
    {
        #region Private members
        bool isInAddRange = false;
        private readonly Dispatcher _currentDispatcher;
        
        #endregion Private members
        #region Public methods
        /// <summary>
        /// Creates a new empty ObservableList of the provided type. 
        /// </summary>
        public ObservableList()
        {
            //Assign the current Dispatcher (owner of the collection) 
            _currentDispatcher = Dispatcher.CurrentDispatcher;
        }
        /// <summary>
	    /// Executes this action in the right thread
	    /// </summary>
	    ///<param name="action">The action which should be executed</param>
	    private void DoDispatchedAction(Action action)
	    {
	        if (_currentDispatcher.CheckAccess())
	            action.Invoke();
	        else
	            _currentDispatcher.Invoke(DispatcherPriority.DataBind, action);
	    }
        /// <summary>
        /// Handles the event when a collection has changed.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // intercept this when it gets called inside the AddRange method.
            if (!isInAddRange)
            {
                DoDispatchedAction(() => base.OnCollectionChanged(e));
            }
        }
        /// <summary>
        /// Adds a collection of items to the ObservableList.
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<T> items)
        {
            isInAddRange = true;
            foreach (T item in items)
            {
                if (item != null)
                    {
                        Add(item);
                }
            }       
            isInAddRange = false;
            var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,items.ToList());
            DoDispatchedAction(() => base.OnCollectionChanged(e));
            
        }
        
        #endregion Public methods
    }
    
