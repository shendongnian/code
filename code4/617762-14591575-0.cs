    <TreeView ...>
        <TreeView.ItemContainerStyle>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
             </Style>
        </TreeView.ItemContainerStyle>
    </TreeView>
