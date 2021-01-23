    <UserControl x:Name="MyUserControl">
        <!-- ... Omitted for brevity ... -->
            <sdk:DataGridTemplateColumn x:Name="MyColumn" Header="User">
                <sdk:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox
                            x:Name="comboBox1"
                            ItemsSource="{Binding SystemUsers, ElementName=MyUserControl}"
                            />
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellTemplate>
            </sdk:DataGridTemplateColumn>
    </UserControl>
