        <TreeView ...>
            <TreeView.Resources>
                    <HierarchicalDataTemplate DataType="{x:Type local:L3Class}" ItemsSource="{Binding L4Collection}" >
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </HierarchicalDataTemplate>
                    <HierarchicalDataTemplate DataType="{x:Type local:Category}" ItemsSource="{Binding L3Collection}" >
                        <StackPanel>
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </HierarchicalDataTemplate>
                    <HierarchicalDataTemplate DataType="{x:Type local:L1Class}" ItemsSource="{Binding CategoryCollection}" >
                        <StackPanel>
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </HierarchicalDataTemplate>
                </TreeView.Resources>
        </TreeView>
