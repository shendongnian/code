        <TreeView ItemsSource="{Binding Outers}">
            <TreeView.ItemTemplate>
                <DataTemplate>
                    <TreeViewItem ItemsSource="{Binding Actions}" Header="{Binding Name}">
                        <TreeViewItem.ItemTemplate>
                            <DataTemplate>
                                <Button Command="{Binding Click}" Content="{Binding Name}" />
                            </DataTemplate>
                        </TreeViewItem.ItemTemplate>
                    </TreeViewItem>
                </DataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
