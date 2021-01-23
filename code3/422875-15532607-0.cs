    <Window       x:Class="WpfApplication2.MainWindow"
                    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:src="clr-namespace:WpfApplication2"
                    Title="MainWindow" 
                   Height="350" 
                    Width="525"
                         >
        <DataGrid ItemsSource="{Binding Items}">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Column 1" Width="120">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Description}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox SelectedIndex="{src:ValidatedBinding SelectedIndex}"
                                      VerticalAlignment="Center" HorizontalAlignment="Center" Width="100">
                                <ComboBoxItem>Not Specified</ComboBoxItem>
                                <ComboBoxItem>First</ComboBoxItem>
                                <ComboBoxItem>Second</ComboBoxItem>
                            </ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Window>
