    <DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False" Height="200" HorizontalAlignment="Left" Margin="10,10,0,0" Name="dataGrid1" VerticalAlignment="Top" Width="200" >
        <DataGrid.Columns>
       
            <!-- The template coloumn -->
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <!-- Each cell is put in to a content presenter so I can change it's content -->
                        <ContentPresenter>
                            <ContentPresenter.Content>
                                <Binding Path="Type">
                                    <Binding.Converter>
                                        <local:SwitchConverter>
                                    
                                            <local:SwitchConverterCase When="1">
                                                <Button Content="{Binding Text}"></Button>
                                            </local:SwitchConverterCase>
    
                                            <local:SwitchConverterCase When="2">
                                                <CheckBox Content="{Binding Text}" />
                                            </local:SwitchConverterCase>
    
    
                                        </local:SwitchConverter>
                                    </Binding.Converter>
                                </Binding>
                            </ContentPresenter.Content>
                        </ContentPresenter>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
