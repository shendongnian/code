     <Window.Resources>
        <ResourceDictionary>
            <DataTemplate x:Key="innertemplate">
                <ToggleButton Content="Expressions..." ButtonBase.Click="ToggleButton_Click" />
            </DataTemplate>
            <DataTemplate x:Key="template">
                <StackPanel DockPanel.Dock="Left">
                    <Label Content="Add destination paths" />
                    <DataGrid ItemsSource="{Binding Destinations}" RowDetailsVisibilityMode="Visible">
                        <DataGrid.Columns>
                            <DataGridTemplateColumn CellTemplate="{StaticResource innertemplate}">
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                        <DataGrid.RowDetailsTemplate>
                            <DataTemplate>
                                <DataGrid ItemsSource="{Binding Expressions}" AutoGenerateColumns="True">
                                </DataGrid>
                            </DataTemplate>
                        </DataGrid.RowDetailsTemplate>
                    </DataGrid>
                </StackPanel>
            </DataTemplate>
        </ResourceDictionary>
    </Window.Resources>
