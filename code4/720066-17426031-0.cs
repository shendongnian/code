    <ListView ItemsSource="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}},Path=DataContext.CurrentSecurityList}"
                  Tag="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}}">
            <ListView.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="Remove" Command="{Binding PlacementTarget.Tag.DataContext.RemoveSecurity, RelativeSource={RelativeSource 
                                    AncestorType=ContextMenu}}"/>
                </ContextMenu>
            </ListView.ContextMenu>
        </ListView>
