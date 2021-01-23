        <DataGrid Grid.Row="0"  
                  AutoGenerateColumns="False" Height="Auto" 
                  SelectionMode="Single" ItemsSource="{Binding MyViewItemModels}"  
                      RowDetailsVisibilityMode="Collapsed" HeadersVisibility="Column" CanUserAddRows="False" 
                      GridLinesVisibility="None" AlternationCount="2" AlternatingRowBackground="GhostWhite" Background="White">
            <DataGrid.Columns>
                <DataGridTemplateColumn IsReadOnly="True" MinWidth="50" Width="70" >
                    <DataGridTemplateColumn.Header>
                        <Border Height="30">
                            <Label Content="My Name"/>
                        </Border>
                    </DataGridTemplateColumn.Header>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox Height="16" ItemsSource="{Binding MyItems, Mode=OneWay}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
