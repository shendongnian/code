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
                        <Grid Background=""Transparent"">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width=""210""/>
                                <ColumnDefinition Width=""210""/>
                            </Grid.ColumnDefinitions>
                            <Grid.RowDefinitions>
                                <RowDefinition Height=""120""/>
                            </Grid.RowDefinitions>
                            <Image Height=""118"" Width=""209"" Tap=""ThumbnailImageTap"" Margin=""0"" Stretch=""Fill"" Source=""{Binding ThumbnailUrl1}"" Tag=""{Binding ClipId1}"" Grid.Column=""0"" VerticalAlignment=""Center"" HorizontalAlignment=""Left""/>
                            <Image Height=""118"" Width=""209"" Tap=""ThumbnailImageTap"" Margin=""0"" Stretch=""Fill"" Source=""{Binding ThumbnailUrl2}"" Tag=""{Binding ClipId2}""  Grid.Column=""1"" VerticalAlignment=""Center"" HorizontalAlignment=""Right""/>
                        </Grid>
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
