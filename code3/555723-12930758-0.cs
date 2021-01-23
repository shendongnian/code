    <DataGrid ItemsSource="{Binding Projects}" SelectedItem="{Binding SelectedProject}" MouseDoubleClick="DataGrid_MouseDoubleClick"> 
        <DataGrid.Resources>
            <Style TargetType="DataGridRow">
                <EventSetter Event="MouseDoubleClick" Handler="DataGridRow_MouseDoubleClick" />
            </Style>
        </DataGrid.Resources>
        <DataGrid.Resources>
            <Style TargetType="DataGridColumnHeader">
                <EventSetter Event="MouseDoubleClick" Handler="DataGridColumnHeader_MouseDoubleClick" />
            </Style>
        </DataGrid.Resources>
    </DataGrid>
