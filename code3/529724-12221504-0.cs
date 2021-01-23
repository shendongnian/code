    <DataGrid ItemsSource="{Binding MyBooksCollection}">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Binding="{Binding Path=IsChecked, Mode=TwoWay}" />
        </DataGrid.Columns>
    </DataGrid>
