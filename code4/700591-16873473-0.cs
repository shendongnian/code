        <DataGrid ItemsSource="{Binding MyItems}" SelectionMode="Single" SelectedCellsChanged="DataGrid_OnSelectedCellsChanged">
            <DataGrid.Columns>
                <DataGridCheckBoxColumn IsReadOnly="True" Binding="{Binding Selected}"/>
                <DataGridTextColumn Binding="{Binding Name}"/>
            </DataGrid.Columns>
        </DataGrid>
    
