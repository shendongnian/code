    <DataGrid ItemsSource="{Binding List}" Margin="0,10,0,0" AutoGenerateColumns="False">
        <DataGrid.CommandBindings>
            <CommandBinding Command="commands:Commands.EditURI" CanExecute="CommandBinding_CanExecute" Executed="CommandBinding_Executed"/>
        </DataGrid.CommandBindings>
        <DataGrid.Columns>
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Button Content="..." Command="controls:Commands.EditURI"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
