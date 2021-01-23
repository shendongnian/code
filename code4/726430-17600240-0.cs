    <Button Content="Test">
        <Button.Resources>
            <viewModel:MenuItemCollection x:Key="FixedMenuItems">
                <MenuItem Header="Fixed Item" />
            </viewModel:MenuItemCollection>
        </Button.Resources>
        <Button.ContextMenu>
            <ContextMenu>
                <ContextMenu.ItemsSource>
                    <CompositeCollection>
                        <CollectionContainer Collection="{StaticResource FixedMenuItems}" />
                        <CollectionContainer Collection="{Binding MyMenuItems}" />
                    </CompositeCollection>
                </ContextMenu.ItemsSource>
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
