    <ListView.Resources>
                                    <ContextMenu x:Key="GvRowMenu" ItemsSource="{Binding ContextMenuItems}">
                                        <ContextMenu.ItemTemplate>
                                            <DataTemplate>
                                                <StackPanel Orientation="Horizontal">
                                                    <Image  Source="{Binding ImagePath}"></Image>
                                                    <TextBlock  Text="{Binding Name}"></TextBlock>
                                                    <MenuItem Click="MenuItem_Click" CommandParameter="{Binding RelativeSource={RelativeSource AncestorType={x:Type ContextMenu}}}"/>
                                                </StackPanel>
                                            </DataTemplate>
                                        </ContextMenu.ItemTemplate>
                                    </ContextMenu>
                                </ListView.Resources>
