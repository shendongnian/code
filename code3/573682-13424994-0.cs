    <TabControl Name="MyTabControl" Background="Green">
                <TabControl.ContextMenu>
                    <ContextMenu Name="MyContextMenu"  StaysOpen="True" ItemsSource="{Binding  Items}">
                        <ContextMenu.ItemTemplate>
                            <DataTemplate >
                                <MenuItem Header="{Binding Header}"  IsEnabled="False" />
                            </DataTemplate>
                        </ContextMenu.ItemTemplate>
                    </ContextMenu>
                </TabControl.ContextMenu>
            </TabControl> 
                                        
