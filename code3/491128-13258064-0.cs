        /// <summary>
        /// Set the column widths to the widest of the items
        /// or the column header text.
        /// </summary>
        /// <param name="useUpdate">Whether to use Begin/End Update methods
        /// to pause the drawing of the list view.</param>
        private void SetColumnWidths(bool useUpdate)
        {
            if(useUpdate)
                list.BeginUpdate();
            int width;
            int totalWidth = 0;
            foreach (ColumnHeader col in list.Columns)
            {
                // The last column's width will be the leftover
                //   width of the list view.
                if (list.Columns.Count != col.DisplayIndex)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize); 
                    width = col.Width;
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    if (width > col.Width)
                        col.Width = width;
                    totalWidth += col.Width;
                }
                else
                {
                    col.Width = (list.ClientSize.Width - totalWidth);
                }
            }
            if(useUpdate)
                list.EndUpdate();
        }
