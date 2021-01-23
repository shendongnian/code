    <DataGrid.Columns>
        <DataGridColumn Header="Fields">
            <DataGridColumn.ItemTemplate>
                <DataTemplate>
                    <ComboBox ItemsSource="{Binding ElementName=MyWindow, Path=DataContext.SomeCategoryList}"
                              SelectedItem="{Binding SomePropertyOnDataItemInRow}" />
            </DataGridColumn.ItemTemplate>
        </DataGridColumn>
    </DataGrid.Columns>
