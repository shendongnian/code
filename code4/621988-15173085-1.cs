    <ListView
        x:Name="itemListView"
        DataContext="{StaticResource ResourceKey=viewmodel}"
        ItemsSource="{Binding Path=Dictionaries}"
        SelectionMode="Multiple">
        
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="IsSelected" Value="{Binding Path=Selected, Mode=TwoWay}"/>
            </Style>
        </ListView.ItemContainerStyle>
        
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid Margin="6">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <StackPanel Grid.Column="0" Margin="0,0,0,0">
                        <TextBlock Text="{Binding Name}"/>
                        <TextBlock Text="{Binding SubName}" TextWrapping="Wrap"/>
                    </StackPanel>
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
