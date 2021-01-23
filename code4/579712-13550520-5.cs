    <DataGrid ItemsSource="{Binding Path=Contents}" AutoGenerateColumns="false">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Row ID" Binding="{Binding Path=ID,UpdateSourceTrigger=PropertyChanged}"/>
            <DataGridTextColumn Header="your row header" Binding="{Binding Path=DisplayContents,UpdateSourceTrigger=PropertyChanged}"/>
        </DataGrid.Columns>
    </DataGrid>
