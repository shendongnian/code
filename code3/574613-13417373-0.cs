            <DataGrid>
                <DataGrid.Columns>
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding DataContext.MyProperty, RelativeSource={RelativeSource AncestorType=MyUserControl}}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                        <DataGridTemplateColumn.CellEditingTemplate>
                            <DataTemplate>
                                <TextBox Text="{Binding DataContext.MyProperty, RelativeSource={RelativeSource AncestorType=MyUserControl}}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellEditingTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
