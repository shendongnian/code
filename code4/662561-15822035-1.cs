        void LoadPictures(int s)
        {
            grdScene.Children.Clear();
            TabControl tab = new TabControl();
            for (int i = s; i <= s + 3; i++)
            {
                BitmapImage bmp = new BitmapImage(new Uri("C:\\img\\" + i + ".png"));
                TabItem tabItem = new TabItem();
                tabItem.Header = "Scene " + i;
                tabItem.Content = new Image(){Source = bmp};
                tab.Items.Add(tabItem);
            }
            grdScene.Children.Add(tab);
        }
