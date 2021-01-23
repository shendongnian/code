        /// <summary>
        /// ContextMenuStrip Opening Action
        /// </summary>
        private void listContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // If there are no items selected, cancel viewing the context menu
            if (connectionListView.SelectedItems.Count <= 0)
            {
                e.Cancel = true;
            }
        }
