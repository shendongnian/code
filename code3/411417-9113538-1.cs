    <TabControl ItemsSource="{Binding TabViewModels}"
                SelectedIndex="{Binding SelectedTabIndex}">
        <TabControl.Resources>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="Header" Value="{Binding Header}" />
            </Style>
            <DataTemplate DataType="{x:Type viewModels:ConfigurationTabViewModel}">
                <views:Configuration />
            </DataTemplate>
            <DataTemplate DataType="{x:Type viewModels:ClassificationTabViewModel}">
                <views:Classification />
            </DataTemplate>
        </TabControl.Resources>
    </TabControl>
