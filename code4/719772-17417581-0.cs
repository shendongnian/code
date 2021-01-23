        LongListSelector listSelector;
        
        private void CreateLongListSelector()
        {
            listSelector = new LongListSelector()
            {
                HideEmptyGroups=false,
                IsGroupingEnabled=false,
            };
            ContentPanel.Children.Add(listSelector);
            listSelector.ItemTemplate = GetDataTemplate();
            
        }
        public DataTemplate GetDataTemplate()
        {
            string xaml = @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
                            <StackPanel Name=""containerStack"" Margin=""0,0,0,0"" Orientation=""Horizontal"">
                            <StackPanel HorizontalAlignment=""Left"" Height=""Auto"" VerticalAlignment=""Top"" Width=""60"" Margin=""3,20,2,20"">
                            <TextBlock Text=""{Binding text}"" TextWrapping=""Wrap"" Style=""{StaticResource PhoneTextLargeStyle}"" FontSize=""{StaticResource PhoneFontSizeMedium}"" Foreground=""White""/>
                            </StackPanel><StackPanel Height=""Auto"" VerticalAlignment=""Top"" Width=""350"" Margin=""2,20,3,20"">
                            <TextBlock Text=""{Binding text}"" TextWrapping=""Wrap"" Style=""{StaticResource PhoneTextLargeStyle}"" FontSize=""{StaticResource PhoneFontSizeMedium}"" Foreground=""White"" Margin=""0""/>
                            <TextBlock Text=""{Binding text}"" TextWrapping=""Wrap"" Style=""{StaticResource PhoneTextLargeStyle}"" FontSize=""{StaticResource PhoneFontSizeMedium}"" Foreground=""DarkBlue"" Margin=""0""/>
                            </StackPanel>
                            </StackPanel>
                            </DataTemplate>";
            DataTemplate res=null;
            try
            {
                res = (DataTemplate)XamlReader.Load(xaml);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return res;
        }
