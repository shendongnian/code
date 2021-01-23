        /// <summary>
        /// Called when the implementer has been navigated to.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (this.SelectedProject == null)   // <-- If event received untill now
                this.ShouldBeVisible = false;
            else
                this.ShouldBeVisible = true;
         }
