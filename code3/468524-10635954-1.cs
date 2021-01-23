    <DataGrid ItemsSource="{Binding MyGridData}" AutoGenerateColumns="False" Name="my_datagrid">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Column1">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <Image Source={Binding GridCellImage}" />
                            <TextBlock Text="{Binding GridCellText}" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
