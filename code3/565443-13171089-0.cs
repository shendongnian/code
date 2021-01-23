    <DataGridComboBoxColumn Header="Life Area" SelectedItemBinding="{Binding YourSelectedItem}">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding YourItemSource}"/>
                <Setter Property="IsReadOnly" Value="True"/>
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding YourItemSource}"/>
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
