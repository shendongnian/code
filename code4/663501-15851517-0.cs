        <Menu ItemsSource="{Binding Connections}">
            <Menu.ItemTemplate>
                <DataTemplate>
                    <MenuItem Header="{Binding}" Click="ConnectionsMenuItem_Clicked">
                        
                    </MenuItem>
                </DataTemplate>
            </Menu.ItemTemplate>
        </Menu>
