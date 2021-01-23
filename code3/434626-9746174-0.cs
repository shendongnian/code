            listView1.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler((a, e) =>
            {
                GridViewColumnHeader headerClicked =
                  e.OriginalSource as GridViewColumnHeader;
                headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
