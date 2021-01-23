     <DataGrid ItemsSource="{Binding DataSet}" AutoGenerateColumns="False">
            <DataGrid.RowStyle>
                <Style TargetType="DataGridRow">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsActive}" Value="False">
                            <Setter Property="Foreground" Value="Gray"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </DataGrid.RowStyle>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}">
                </DataGridTextColumn>
                <DataGridCheckBoxColumn Binding="{Binding IsActive, Mode=TwoWay}">
                </DataGridCheckBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
