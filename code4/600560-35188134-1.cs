        /// <summary>
        /// Enables autoresizing for specific listview.
        /// You can specify how much to scale in columnScaleNumbers array - length of that array
        /// should match column count which you have.
        /// </summary>
        /// <param name="listView">control for which to enable auto-resize</param>
        /// <param name="columnScaleNumbers">Percentage or numbers how much each column will be scaled.</param>
        private void EnableAutoresize(ListView listView, params int[] columnScaleNumbers)
        {
            listView.View = View.Details;
            for( int i = 0; i < columnScaleNumbers.Length; i++ )
            {
                if( i >= listView.Columns.Count )
                    break;
                listView.Columns[i].Tag = columnScaleNumbers[i];
            }
            listView.SizeChanged += lvw_SizeChanged;
            DoResize(listView);
        }
        void lvw_SizeChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            DoResize(listView);
        }
        bool Resizing = false;
        void DoResize( ListView listView )
        {
            // Don't allow overlapping of SizeChanged calls
            if (!Resizing)
            {
                // Set the resizing flag
                Resizing = true;
                if (listView != null)
                {
                    float totalColumnWidth = 0;
                    // Get the sum of all column tags
                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);
                    // Calculate the percentage of space each column should 
                    // occupy in reference to the other columns and then set the 
                    // width of the column to that percentage of the visible space.
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }
            // Clear the resizing flag
            Resizing = false;            
        }
