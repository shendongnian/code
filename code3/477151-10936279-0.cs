        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The
        /// Parameter property provides the group to be displayed.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Assign a bindable group to this.DefaultViewModel["Group"]
            // TODO: Assign a collection of bindable items to this.DefaultViewModel["Items"]
            FeedData feedData = e.Parameter  as FeedData;
            if (feedData != null)
            {
                this.DefaultViewModel["Feed"] = feedData;
                this.DefaultViewModel["Items"] = feedData.Items;
            }
            // Select the first item automatically unless logical page navigation is
            // being used (see the logical page navigation #region below.)
            if (!this.UsingLogicalPageNavigation()) this.itemsViewSource.View.MoveCurrentToFirst();
        }
