    <TreeView ItemsSource="{Binding League}">
        <!-- Conference template -->
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Teams}">
                <TextBlock Foreground="Red" Text="{Binding Name}" />
                <!-- Team template -->
                <HierarchicalDataTemplate.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding Name}"/>
                            <ItemsControl ItemsSource="{Binding Players}">
                                <ItemsControl.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <StackPanel Orientation="Horizontal">
                                        </StackPanel>
                                    </ItemsPanelTemplate>
                                </ItemsControl.ItemsPanel>
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <Button Content="{Binding }"/>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </StackPanel>
                    </DataTemplate>
                </HierarchicalDataTemplate.ItemTemplate>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
