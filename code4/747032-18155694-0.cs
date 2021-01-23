    public class DynamicDataTemplateSelector: DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is Task)
            {
                Model model = item as Model;
                return element.FindResource(model.DisplayAs + "Template");
            }
            return null;
        }
    }
    <DataGrid>
        <DataGrid.Resources>
            <DataTemplate x:Key="TextBoxTemplate">
                <TextBox Text="{Binding Value}"/>
            </DataTemplate>
            <DataTemplate x:Key="CheckBoxTemplate">
                <CheckBox IsChecked="{Binding Value}"/>
            </DataTemplate>
            <DataTemplate x:Key="ComboBoxTemplate">
                <ComboBox SelectedItem="{Binding Value}"/>
            </DataTemplate>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="RowName">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{DisplayName}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
           
            <DataGridTemplateColumn Header="Data" 
                 CellTemplateSelector="{StaticResource DynamicDataTemplateSelector}"/>
        <DataGrid.Columns>
    <DataGrid/>
