    <DataGridTemplateColumn x:Name="CheckBoxColumn" local:MyDependencyClass.IsEnabledColumn="False" Width="110" Header="CheckBox Header">
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <CheckBox Content="My CheckBox" IsEnabled="{Binding Source={x:Reference Name=CheckBoxColumn}, Path=(local:MyDependencyClass.IsEnabledColumn)}" IsChecked="False" />
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
