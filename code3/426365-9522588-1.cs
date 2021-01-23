        <DataGrid ItemsSource="{Binding Users}" AutoGenerateColumns="False" HorizontalAlignment="Left" Name="scratchGrid" CanUserAddRows="False"
                  VerticalScrollBarVisibility="Auto" SelectionUnit="Cell">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}" Header="User Name" Width="200">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="{x:Type DataGridCell}">
                            <Setter Property="IsSelected" Value="{Binding NameSelected}" />
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding Age}" Header="User Age" Width="80">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="{x:Type DataGridCell}">
                            <Setter Property="IsSelected" Value="{Binding AgeSelected}" />
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
