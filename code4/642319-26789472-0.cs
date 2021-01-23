    <TabControl ItemsSource="{Binding MenuItems}" TabStripPlacement="Top">
        <TabControl.ItemTemplate>
            <DataTemplate DataType="{x:Type ControlViewModels:MenuItemViewModel}"> 
                <StackPanel Orientation="Horizontal">
                    <Image Source="{Binding ImageSource}" Margin="0,0,10,0" />
                    <TextBlock Text="{Binding HeaderText}" FontSize="16" />
                </StackPanel>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate DataType="{x:Type ControlViewModels:MenuItemViewModel}">
                <ContentControl Content="{Binding ViewModel}" />
            </DataTemplate>
        </TabControl.ContentTemplate>
        <TabControl.ItemContainerStyle>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="IsSelected" Value="{Binding IsSelected}" />
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>
