    <Grid>
        <TreeView ItemsSource="{Binding Nodes}">
            <TreeView.Resources>
                <HierarchicalDataTemplate ItemsSource="{Binding Nodes}" DataType="{x:Type local:Node}">
                    <TextBlock Text="{Binding Text}"/>
                </HierarchicalDataTemplate>
            </TreeView.Resources>
            <TreeView.ItemContainerStyle>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="local:UserControl1.SelectedItemDoubleClickedCommandAttached" 
                            Value="{Binding SelectedItemDoubleClickedCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type UserControl}}}" />
                </Style>
            </TreeView.ItemContainerStyle>
            
        </TreeView>
    </Grid>
