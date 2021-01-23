    ...
    <Window.Resources>
        <DataTemplate x:Key="LineTemplate">
            <Line />
        </DataTemplate>
        <DataTemplate x:Key="EllipseTemplate">
            <Ellipse />
        </DataTemplate>
        ... etc
    </Window.Resources>
    ...
    <TreeView  Grid.Column="0"
              ItemsSource="{Binding Layers}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding SubLayers}">
                <StackPanel Orientation="Horizontal">
                    <Canvas Background="LightGray">
                        <ContentControl Content="{Binding}">
                            <ContentControl.Style>
                                <Style TargetType="ContentControl">
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding Path=Type}" Value="{StaticResource local:GeoType.Line}">
                                            <Setter Property="ContentTemplate" Value="{StaticResource LineTemplate}" />
                                        </DataTrigger>
                                        <DataTrigger Binding="{Binding Path=Type}" Value="{StaticResource local:GeoType.Ellipse}">
                                            <Setter Property="ContentTemplate" Value="{StaticResource EllipseTemplate}" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </ContentControl.Style>
                        </ContentControl>
                    </Canvas>
                    <TextBlock Margin="20,0,0,0" Text="{Binding Path=Name}"/>
                </StackPanel>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
