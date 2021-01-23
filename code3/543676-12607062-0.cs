     <DataGrid AutoGenerateColumns="False" Height="256" HorizontalAlignment="Left" Name="dgEmp" VerticalAlignment="Top" Width="490"  ItemsSource="{Binding DeleteData,Mode=TwoWay}" Margin="6,7,0,0" Grid.RowSpan="3">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="ID" Binding="{Binding ID,Mode=TwoWay}" IsReadOnly="True" Visibility="Hidden"/>
                            <DataGridTextColumn Header="Description" Binding="{Binding Description,Mode=TwoWay}" IsReadOnly="True"/>
                            <DataGridTextColumn Header="Amount" Binding="{Binding Amount,Mode=TwoWay}" IsReadOnly="True"/>
                            <DataGridTextColumn Header="Date" Binding="{Binding Date,Mode=TwoWay}" IsReadOnly="True"/>
                            <DataGridTextColumn Header="Remark" Binding="{Binding Remark,Mode=TwoWay}" IsReadOnly="True"/>
                            <DataGridTemplateColumn>
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="Update" x:Name="btnUpdate"
                                Click="btnUpdate_Click"></Button>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                    </DataGrid>
