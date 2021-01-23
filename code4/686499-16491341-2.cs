    private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
            {
                foreach (UIElement item in (sender as ListBox).Items)
                {
                    if ((sender as ListBox).SelectedItem == item)
                    {
                        foreach (UIElement InnerItem in (item as StackPanel).Children)
                        {
                            if ((InnerItem is TextBlock) && (InnerItem as TextBlock).Name.Equals("title"))
                            {
                                MessageBox.Show((InnerItem as TextBlock).Text);
                            }
                        }
                    }
                }
            }</pre>
