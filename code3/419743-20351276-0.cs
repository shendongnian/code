    <sdk:DataGrid x:Name="NoteList"
        AutoGenerateColumns="False"
        GridLinesVisibility="None"
        HeadersVisibility="None"
        IsReadOnly="True"
        ItemsSource="{Binding NoteList,Mode=OneWay}">
        <sdk:DataGrid.Columns>
            <sdk:DataGridTemplateColumn Width="Auto">
                <sdk:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding NoteDescription, Mode=OneWay}"
                                 Background="{Binding NoteHighlighted, 
                                    Converter={StaticResource BooleanToColourConverter}}"/>
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellTemplate>
            </sdk:DataGridTemplateColumn>
        </sdk:DataGrid.Columns>
    </sdk:DataGrid>
