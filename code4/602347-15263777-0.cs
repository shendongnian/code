    public TreeViewItem CreateTreeViewItem(string nodeName, string headerText, string ImagePath)
    {
            TreeViewItem treeViewItem = new TreeViewItem();
            try
            {
                StackPanel stackPanel = new StackPanel();
                Label lblHeaderText = new Label();
                Image imgFrontIcon;
                imgFrontIcon = new Image(); 
                stackPanel.Orientation = Orientation.Horizontal;
                
                if (ImagePath != null && ImagePath != string.Empty)
                {
                    Uri uri = new Uri(@"pack://application:,,," + ImagePath);
                    BitmapImage bitMapSource = new BitmapImage();
                    bitMapSource.BeginInit();
                    bitMapSource.UriSource = uri;
                    bitMapSource.EndInit();
                    imgFrontIcon.Source = bitMapSource;
                }
                
                lblHeaderText.Content = headerText;
                stackPanel.Children.Add(imgFrontIcon);
                stackPanel.Children.Add(lblHeaderText);
                nodeName = nodeName.Replace("-", "_");
                treeViewItem.Name = nodeName;
                treeViewItem.Header = stackPanel;
            }
            catch (Exception ex)
            { }
            return treeViewItem
    }
