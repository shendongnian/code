    <TabControl HorizontalAlignment="Left" Height="250" Margin="0,10,0,0" VerticalAlignment="Top" Width="292">
            <TabItem Header="TabItem">
                <Grid Background="#FFE5E5E5">
                    <TabControl>
                        <TabItem Header="TabItem">
                            <Grid>
                                <DataGrid x:Name="_dgvInventory"
                                         VirtualizingStackPanel.IsVirtualizing="True"
                                         VirtualizingStackPanel.VirtualizationMode="Recycling"
                                         Grid.Row="1"
                                         AutoGenerateColumns="False"
                                         ItemsSource="{Binding}"
                                         IsReadOnly="True"
                                         SelectionMode="Single"
                                         SelectionUnit="FullRow"
                                         RowHeaderWidth="30"
                                         SelectionChanged="DGVInventory_SelectionChanged"
                                         LoadingRow="DataGridLoadingRow"
                                         VerticalScrollBarVisibility="Auto"
                                         HorizontalScrollBarVisibility="Auto">
                                    <DataGrid.Columns>
                                        <DataGridTextColumn Header="Status"
                                                              Binding="{Binding Status}"/>
                                        <DataGridTextColumn Header="Tag ID"
                                                              Binding="{Binding TagId}"/>
                                        <DataGridTextColumn Header="Description"
                                                              Binding="{Binding Description}"/>
                                        <DataGridTextColumn Header="Part Number"
                                                              Binding="{Binding PartNumber}"/>
                                        <DataGridTextColumn Header="Serial Number"
                                                              Binding="{Binding SerialNumber}"/>
                                        <DataGridTextColumn Header="Location"
                                                              Binding="{Binding Location}"/>
                                        <DataGridTextColumn Header="Room"
                                                              Binding="{Binding Room}"/>
                                        <DataGridTextColumn Header="Inventory"
                                                              Binding="{Binding Inventory}"/>
                                        <DataGridTextColumn Header="Comment"
                                                              Binding="{Binding OwnedComment}"/>
                                    </DataGrid.Columns>
                                    <DataGrid.ContextMenu>
                                        <ContextMenu>
                                            <MenuItem Header="Search"
                                                     Click="SearchParts_Click" />
                                            <MenuItem Header="Masked Search" Click="MaskedSearchMenuItem_Click"/>
                                        </ContextMenu>
                                    </DataGrid.ContextMenu>
                                    <DataGrid.RowStyle>
                                        <Style TargetType="{x:Type DataGridRow}">
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding Status}"
                                                             Value="Inv:found">
                                                    <Setter Property="Background"
                                                          Value="GreenYellow"/>
                                                </DataTrigger>
                                                <DataTrigger Binding="{Binding Status}"
                                                             Value="Inv:unfound">
                                                    <Setter Property="Background"
                                                          Value="Salmon"/>
                                                </DataTrigger>
                                                <DataTrigger Binding="{Binding Status}"
                                                             Value="unknown">
                                                    <Setter Property="Background"
                                                          Value="Yellow"/>
                                                </DataTrigger>
                                                <DataTrigger Binding="{Binding Status}"
                                                             Value="stray">
                                                    <Setter Property="Background"
                                                          Value="LightBlue"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </DataGrid.RowStyle>
                                </DataGrid>
                            </Grid>
                        </TabItem>
                    </TabControl>
                </Grid>
            </TabItem>
            <TabItem Header="TabItem">
                <Grid Background="#FFE5E5E5"/>
            </TabItem>
        </TabControl>
