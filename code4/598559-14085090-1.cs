    <TreeViewItem.ItemContainerStyle>
      <Style TargetType="TreeViewItem">
        <Setter Property="commandBehaviors:MouseDoubleClick.Command" 
                Value="{Binding ElementName=treeView, Path=DataContext.SelectOtherTab}" />
        <Setter Property="commandBehaviors:MouseDoubleClick.CommandParameter" 
                Value="{Binding }" />
      </Style>
    </TreeViewItem.ItemContainerStyle>
