     <DataGrid ItemsSource="{Binding MyItems}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Column1Data}" HorizontalAlignment="Stretch">
                                <TextBlock.ContextMenu>
                                    <ContextMenu>
                                        <MenuItem Header="Col 1 Item 1"/>
                                        <MenuItem Header="Col 1 Item 2"/>
                                    </ContextMenu>
                                </TextBlock.ContextMenu>
                            </TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox IsChecked="{Binding Column2Data}" HorizontalAlignment="Stretch" >
                                <CheckBox.ContextMenu>
                                    <ContextMenu>
                                        <MenuItem Header="Col 2 Item 1"/>
                                        <MenuItem Header="Col 2 Item 2"/>
                                    </ContextMenu>
                                </CheckBox.ContextMenu>
                            </CheckBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
