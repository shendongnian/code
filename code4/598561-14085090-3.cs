    <TreeView Name="treeView" 
              ItemsSource="{Binding ClassCollection}"
              ItemContainerStyle="{StaticResource TreeViewItemStyle}"  
              Grid.Row="1" Grid.Column="1">
        <TreeView.Resources>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="Header" Value="ProjectName" />
                <Setter Property="ContextMenu" Value="{StaticResource AddClassMenu}" />
                <Setter Property="ItemTemplate" Value="{DynamicResource ClassDataTemplate}" />
                <Setter Property="commandBehaviors:MouseDoubleClick.Command" 
                        Value="{Binding ElementName=treeView, Path=DataContext.SelectOtherTab}" />
                <Setter Property="commandBehaviors:MouseDoubleClick.CommandParameter" 
                        Value="{Binding }" />
            </Style>
        </TreeView.Resources>
    </TreeView>
