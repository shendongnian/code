        /// <summary>
        /// When focus is lost, make sure that we close the popup if needed.
        /// </summary>
        private void OnPreviewAnyControlGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            // If we are not open then we are done.  No need to go further
            if (!IsOpen) return;
            // See if our new control is on a popup
            var popupParent = VLTreeWalker.FindParentControl<Popup>((DependencyObject)e.NewFocus);
            
            // If the new control is not the same popup in our current instance then we want to close.
            if ((popupParent == null) || (this.popup != popupParent))
            {
                popupParent.IsOpen = false;
            }
        }
