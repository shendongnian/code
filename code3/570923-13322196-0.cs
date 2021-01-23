    <DataGrid ItemsSource="{Binding MyData}" AutoGenerateColumns="False">
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                        <DataGridTemplateColumn Header="Age">
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                    <wpfToolkit:IntegerUpDown Value="{Binding Age, UpdateSourceTrigger=PropertyChanged}" />
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
                    </DataGrid.Columns>
                </DataGrid>
