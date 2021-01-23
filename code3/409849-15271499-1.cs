    private void PopulateListView(List<string> fileNames)
    {
        using (Graphics g = this.CreateGraphics())
        {
            int longestTextWidth = 0;
            int longestTextIndex = 0;
            for (int i = 0; i < fileNames.Count; i++)
            {
                ListViewItem item = new ListViewItem(fileNames[i]);
                item.ImageIndex = 0; // Do whatever you do to choose the image.
                fileNamesListView.Items.Add(item);
                // Find the longest file name.
                int textWidth = Size.Round(g.MeasureString(fileNames[i], fileNamesListView.Font)).Width;
                if (textWidth > longestTextWidth)
                {
                    longestTextWidth = textWidth;
                    longestTextIndex = i;
                }
            }
            // Find the width of the image used.
            int imageWidth = filesImageList.Images[fileNamesListView.Items[longestTextIndex].ImageIndex].Width;
            fileNamesListView.Columns[0].Width = longestTextWidth + imageWidth;
        }
    }
