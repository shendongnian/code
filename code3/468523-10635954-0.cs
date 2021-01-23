    <DataGrid ItemsSource="{Binding MyGridData}" AutoGenerateColumns="False" Name="my_datagrid">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Column1">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <Image Source={Binding GridCellImage}"></Image>
                            <TextBlock Text="{Binding GridCellText}">Your text goes here, your image goes above</TextBlock>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
