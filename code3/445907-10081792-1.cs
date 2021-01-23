            private void changeGridSizeDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                changeGridSizeDropDownButton.Text = e.ClickedItem.Text;
                gridSize = Int32.Parse(e.ClickedItem.Text);
            }
        }
