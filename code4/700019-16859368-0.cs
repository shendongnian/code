    <Window.Resources>
      <CommandBehaviors:IsRootNodeConverter x:Key="IsRootNodeConverter" />
    </Window.Resources>
    <Grid>
      <TreeView>
        <TreeView.ItemContainerStyle>
          <Style TargetType="{x:Type TreeViewItem}">
            <Setter Property="CommandBehaviors:MouseDoubleClick.Command"
                    Value="{Binding ConnectDb}" />
            <Setter Property="CommandBehaviors:MouseDoubleClick.CommandParameter"
                    Value="{Binding Path=SelectedItem,
                                    RelativeSource={RelativeSource Self}}" />
            <Setter Property="Foreground"
                    Value="Black" />
            <Style.Triggers>
              <DataTrigger Binding="{Binding Path=.,
                                              RelativeSource={RelativeSource Self},
                                              Converter={StaticResource IsRootNodeConverter}}"
                            Value="True">
                <Setter Property="CommandBehaviors:MouseDoubleClick.Command"
                        Value="{Binding ConnectServer}" />
                <Setter Property="Foreground"
                        Value="Tomato" />
              </DataTrigger>
            </Style.Triggers>
          </Style>
        </TreeView.ItemContainerStyle>
        <TreeView.ItemTemplate>
          <HierarchicalDataTemplate>
            <!--<TreeViewItem>-->
              <TextBlock Text="{Binding}" />
            <!--</TreeViewItem>-->
          </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
        <TreeViewItem Header="1">
          <TreeViewItem Header="A" />
          <TreeViewItem Header="B">
            <TreeViewItem Header="AA" />
            <TreeViewItem Header="AB" />
            <TreeViewItem Header="AC" />
          </TreeViewItem>
          <TreeViewItem Header="C" />
        </TreeViewItem>
      </TreeView>
    </Grid>
