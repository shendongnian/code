        <DataGrid ItemsSource="{Binding MyList}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="ID" Binding="{Binding MyID}" />
                <DataGridTemplateColumn Header="Buttons">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="{Binding MyString}" Command="{Binding MyCommand}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
