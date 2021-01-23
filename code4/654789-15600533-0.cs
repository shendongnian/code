         <DataGrid x:Name="ColumnMappings" DataContext="{StaticResource ColumnMappingsViewSource}" ItemsSource="{Binding}" Margin="10,146,10,40" Background="{DynamicResource ControlContainerBackgroundBrush}" BorderBrush="{DynamicResource ControlContainerBorderBrush}" AlternationCount="2" HeadersVisibility="Column" GridLinesVisibility="Horizontal" AutoGenerateColumns="False" SelectionMode="Single" RowBackground="{DynamicResource RowBackGroundBrush}" AlternatingRowBackground="{DynamicResource RowAlternatingBackGroundBrush}" CanUserDeleteRows="False" CanUserAddRows="False" IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding ColumnName}" ClipboardContentBinding="{x:Null}" Header="Excel Kolom" Width="5*"/>
                <DataGridComboBoxColumn ItemsSource="{Binding Source={StaticResource EntityPropertiesViewSource}}" SelectedItemBinding="{Binding EntityProperty}" DisplayMemberPath="DisplayName" Header="Database Kolom" Width="5*"/>
                <DataGridTemplateColumn Header="Database Kolom" Width="5*">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding EntityProperties}"
                                      DisplayMemberPath="DisplayName" 
                                      SelectedItem="{Binding EntityProperty, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
