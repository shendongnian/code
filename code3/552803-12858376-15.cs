        <TreeView x:Name="MyTreeView" ItemsSource="{Binding TreeItems}">
            <TreeView.ItemContainerStyle>
                <Style TargetType="TreeViewItem">
                    <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                    <Setter Property="IsExpanded" Value="{Binding IsExpanded}"/>
                    <Setter Property="my:TreeViewItemCommandBehaviour.Command" 
                            Value="{Binding ElementName=MyTreeView, Path=DataContext.TreeItemSelectedCommand}" />
                    <Setter Property="my:TreeViewItemCommandBehaviour.CommandParameter" Value="{Binding}" />
                </Style>
            </TreeView.ItemContainerStyle>
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding SubItems}">
                    <TextBlock Text="{Binding Header}" />
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
