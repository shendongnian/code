    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Path=Data}">
        <DataGrid.Resources>
            <DataTemplate x:Key="TextBoxTemplate">
                <TextBox Text="{Binding Path=Text, StringFormat=c0}" />
            </DataTemplate>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Department" Binding="{Binding Path=Department, Mode=OneTime}" />
            <DataGridTextColumn Header="Name" Binding="{Binding Path=Name, Mode=OneTime}" />
            <DataGridTemplateColumn Header="Sales">
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <ContentControl x:Name="salesControl" DataContext="{Binding Path=.}">
                            <TextBlock Text="{Binding Path=Sales, Mode=TwoWay, StringFormat=c0}" />
                        </ContentControl>
                        <DataTemplate.Triggers>
                            <DataTrigger Binding="{Binding Department}" Value="Retail">
                                <Setter TargetName="salesControl" Property="ContentTemplate" Value="{StaticResource TextBoxTemplate}" />
                            </DataTrigger>
                        </DataTemplate.Triggers>
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Sales, StringFormat=c0}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
