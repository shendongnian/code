            private void changeGridSizeDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                changeGridSizeDropDownButton.Text = e.ClickedItem.Text;
                // This line converts my list gridsize options like 64, 32, and 16
                // and Parses that text into the new selected gridsize.
                gridSize = Int32.Parse(e.ClickedItem.Text);
            }
        }
