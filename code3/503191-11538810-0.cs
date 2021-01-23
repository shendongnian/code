        <local:CellViewModelToTagConverter x:Key="CellViewModelToTagConverter" />
        
        <DataGrid AutoGenerateColumns="False"
                  EnableRowVirtualization="True"
                  ItemsSource="{Binding}"
                  Margin="12,236,12,0"
                  Name="conflictedDevicesDataGrid"
                  RowDetailsVisibilityMode="VisibleWhenSelected"
                  Grid.ColumnSpan="2"
                  AlternatingRowBackground="#2FFF0000"
                  IsManipulationEnabled="False">
            <DataGrid.Columns>
                <!--binding to the Text property of the CellViewModel for the column n°0-->
                <DataGridTextColumn Binding="{Binding [0].Text}">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="DataGridCell">
                            <!--this part is the most important, this is where you transfer the right dataContext to the cell-->
                            <Setter Property="Tag">
                                <Setter.Value>
                                    <MultiBinding Converter="{StaticResource CellViewModelToTagConverter}" Mode="OneWay" UpdateSourceTrigger="PropertyChanged">
                                        <Binding />
                                        <Binding RelativeSource="{x:Static RelativeSource.Self}"/>
                                    </MultiBinding>
                                </Setter.Value>
                            </Setter>
                            <!--and here, you bind the Background property-->
                            <Setter Property="Background" Value="{Binding Tag.Background, RelativeSource={RelativeSource Self}, Mode=OneWay}" />
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
