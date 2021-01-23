    <TreeView.ItemTemplate>
        <HierarchicalDataTemplate DataType="model:Item"
                                  ItemsSource="{Binding Children}">
            <Grid Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=UserControl}}">
                <Grid.ContextMenu>
                    <ContextMenu>
                        <MenuItem Header="Add Category"
                                  Command="{Binding Path=PlacementTarget.Tag.AddEntityCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
                    </ContextMenu>
                </Grid.ContextMenu>
                <TextBlock Text="{Binding Description}" Margin="0,0,10,0" />
            </Grid>
        </HierarchicalDataTemplate>
    </TreeView.ItemTemplate>
