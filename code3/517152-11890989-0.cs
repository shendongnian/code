The path for the binding on the second column should be the property name: BookYearSemester, not the class name YearSemester. Try: 
    <DataGrid x:Name="dagtagridPublishedBooks" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Title" Binding="{Binding Title}" />
            <DataGridTextColumn Header="YearSemester" Binding="{Binding BookYearSemester}" />
        </DataGrid.Columns>
    </DataGrid>
