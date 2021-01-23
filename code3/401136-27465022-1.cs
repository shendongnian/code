    <DataGrid Grid.Column="0">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Vanilla" Visibility="{dataGridBox:RootBinding Binding={Binding Visibility}}" />
            <DataGridTextColumn Header="Converter" Visibility="{dataGridBox:RootBinding Binding={Binding Visible, 
                                                                                        Converter={StaticResource BooleanToVisibilityConverter}}}" />
        </DataGrid.Columns>
    </DataGrid>
