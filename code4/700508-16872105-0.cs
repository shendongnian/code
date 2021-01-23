    <TreeView ItemsSource="{Binding ServerItems}">
      <TreeView.ItemContainerStyle>
        <Style TargetType="{x:Type TreeViewItem}">
          <Style.Resources>
            <CommandBehaviors:GetElementTypeConverter x:Key="GetElementTypeConverter" />
          </Style.Resources>
          <Setter Property="CommandBehaviors:MouseDoubleClick.Command"
                  Value="{Binding Path=DataContext.ConnectDb,
                                  RelativeSource={RelativeSource FindAncestor,
                                                                  AncestorType={x:Type TreeView}}}" />
          <Setter Property="CommandBehaviors:MouseDoubleClick.CommandParameter"
                  Value="{Binding Path=.}" />
          <Setter Property="Foreground"
                  Value="Black" />
          <Style.Triggers>
            <DataTrigger Binding="{Binding Path=.,
                                            Converter={StaticResource GetElementTypeConverter}}"
                          Value="{x:Type CommandBehaviors:ServerItem}">
              <Setter Property="CommandBehaviors:MouseDoubleClick.Command"
                      Value="{Binding Path=DataContext.ConnectServer,
                                      RelativeSource={RelativeSource FindAncestor,
                                                                      AncestorType={x:Type TreeView}}}" />
              <Setter Property="Foreground"
                      Value="Tomato" />
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </TreeView.ItemContainerStyle>
      <TreeView.ItemTemplate>
        <HierarchicalDataTemplate ItemsSource="{Binding Databases}">
          <TextBlock Text="{Binding}" />
        </HierarchicalDataTemplate>
      </TreeView.ItemTemplate>
    </TreeView>
