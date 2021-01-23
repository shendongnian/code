                <sdk:TreeView.ItemTemplate>
                <DataTemplate>
                    <sdk:TreeViewItem Header="{Binding HeaderName}" ItemsSource="{Binding ListTemplates}">
                        <sdk:TreeViewItem.ItemTemplate>
                            <DataTemplate>
                                <sdk:TreeViewItem Header="{Binding Name}"  GotFocus="TreeViewItem_GotFocus"/>
                            </DataTemplate>
                        </sdk:TreeViewItem.ItemTemplate>
                        
                        
                    </sdk:TreeViewItem>
                </DataTemplate>
            </sdk:TreeView.ItemTemplate>
            </sdk:TreeView>
