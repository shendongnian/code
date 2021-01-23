    <HierarchicalDataTemplate ItemsSource="{Binding Models}">
        <TextBlock Text="{Binding Header}"
                   Tag="{Binding DataContext, RelativeSource=
                   {RelativeSource Mode=FindAncestor, AncestorType=Window}}">
             <TextBlock.ContextMenu>
                  <ContextMenu>
                      <MenuItem Header="Server" Command="{Binding 
                                PlacementTarget.Tag.AddServerCommand,
                                RelativeSource={RelativeSource Mode=FindAncestor, 
                                AncestorType=ContextMenu}}"/>
                   </ContextMenu>
              </TextBlock.ContextMenu>
          </TextBlock>
    </HierarchicalDataTemplate>
