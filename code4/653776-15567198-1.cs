    <ContextMenu ItemsSource="{Binding MyCommandList}">
            <ContextMenu.ItemTemplate >
                    <DataTemplate DataType="MenuItem">
                            <MenuItem Header="{Binding Displayname}" Command="{Binding MyContextMenuCommand}"></MenuItem>
                        </DataTemplate>
                </ContextMenu.ItemTemplate>
        </ContextMenu>
