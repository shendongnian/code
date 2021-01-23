    <TreeView x:Name="MyTreeView" ItemsSource="{Binding TreeItems}" 
                  my:TreeViewSelectedItemProperty.IsSelectedItemBound="True"
                  my:TreeViewSelectedItemProperty.SelectedItem="{Binding SelectedItem}">
            <TreeView.ItemContainerStyle>
                <Style TargetType="TreeViewItem">
                    <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                    <Setter Property="IsExpanded" Value="{Binding IsExpanded}"/>
                </Style>
            </TreeView.ItemContainerStyle>
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding SubItems}">
                    <TextBlock Text="{Binding Header}" />
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
