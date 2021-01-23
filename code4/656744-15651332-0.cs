    <ContextMenu DataContext="{Binding PlacementTarget.DataContext, RelativeSource={RelativeSource Self}}" Visibility="{Binding ShowContextMenu}" ItemsSource="{Binding ContextMenu}">
        <ContextMenu.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                <TextBlock Text="{Binding Header}"  />
                <HierarchicalDataTemplate.ItemContainerStyle>
                    <Style TargetType="MenuItem">
                        <Setter Property="Command" Value="{Binding Execute}"/>
                    </Style>
                </HierarchicalDataTemplate.ItemContainerStyle>
            </HierarchicalDataTemplate>
        </ContextMenu.ItemTemplate>
        
        <!-- this is what you're missing -->
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Command" Value="{Binding Execute}"/>
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
