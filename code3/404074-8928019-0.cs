    <Window.Resources>
            <DataTemplate x:Key="ProviderStringTemplate" DataType="{x:Type System:String}">
                <TextBox VerticalAlignment="Center" Text="{Binding Value, Mode=TwoWay, UpdateSourceTrigger=LostFocus}" Width="200" />
            </DataTemplate>
            <DataTemplate x:Key="ProviderBooleanTemplate" DataType="{x:Type System:Boolean}">
                <CheckBox Margin="15,0,0,0" VerticalAlignment="Center" IsChecked="{Binding Value, Mode=TwoWay, UpdateSourceTrigger=LostFocus}" />
            </DataTemplate>
            <Windows:ProviderPropertyTemplateSelector x:Key="templateSelector" />
        </Window.Resources>    
    <DataGrid AutoGenerateColumns="False" Name="dataGridProviderProperties" Height="215" FontSize="11" HorizontalGridLinesBrush="#FFC1C1C1" 
                                VerticalGridLinesBrush="#FFC1C1C1" Padding="0" Background="#00000000" HorizontalScrollBarVisibility="Auto" 
                                  CanUserResizeRows="False" AlternationCount="2" AlternatingRowBackground="#05000000" CanUserAddRows="False" 
                                  DataContext="{Binding}" ItemsSource="{Binding Properties}" VerticalAlignment="Center" Width="345" 
                                VerticalContentAlignment="Center" IsManipulationEnabled="False" CanUserReorderColumns="False" SelectionUnit="Cell">
                            <DataGrid.Columns>
                                <DataGridTemplateColumn Header="Key" Width="100">
                                    <DataGridTemplateColumn.CellTemplate>
                                        <DataTemplate>
                                            <Label VerticalContentAlignment="Center" Height="27" VerticalAlignment="Center" Content="{Binding Key}" Padding="3"></Label>
                                        </DataTemplate>
                                    </DataGridTemplateColumn.CellTemplate>
                                </DataGridTemplateColumn>
                                <DataGridTemplateColumn Header="Value" CellTemplateSelector="{StaticResource templateSelector}" CanUserSort="True" Width="200" />
                            </DataGrid.Columns>
                        </DataGrid>
    
        public class ProviderPropertyTemplateSelector : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                var property = item as Property<object>;
    
                if (property == null)
                    return null;
    
                if (property.Value is Boolean)
                    return ((FrameworkElement)container).FindResource("ProviderBooleanTemplate") as DataTemplate;
    
                if (property.Value is String || property.Value is int)
                    return ((FrameworkElement)container).FindResource("ProviderStringTemplate") as DataTemplate;
    
                return null;
            }
        }
