    <UserControl x:Name="MyUserControl">
        <UserControl.Resources>
            <CollectionViewSource
                x:Key="MyCollectionViewSource"
                Source="{Binding SystemUsers, ElementName=MyUserControl}"
                />
        </UserControl.Resources>
        <!-- ... Omitted for brevity ... -->
            <sdk:DataGridTemplateColumn x:Name="MyColumn" Header="User">
                <sdk:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox
                            x:Name="comboBox1"
                            ItemsSource="{Binding Source={StaticResource MyCollectionViewSource}}"
                            />
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellTemplate>
            </sdk:DataGridTemplateColumn>
    </UserControl>
