     <ListView Name="list" Grid.Row="4">
                <ListView.View>
                    <GridView >
                        <GridView.Columns>
    
                            <GridViewColumn Width="250" DisplayMemberBinding="{Binding Name}" />
    
                            <GridViewColumn >
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="Download" Click="fileDownloadClick" />
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
    
                            <GridViewColumn>
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="Share"  Click="fileShareClick"  >
                                            <Button.Style>
                                                <Style TargetType="Button">
                                                    <Style.Triggers>
                                                        <DataTrigger Binding="{Binding IsShareAllowed}" Value="false">
                                                            <Setter Property="IsEnabled" Value="false"/>
                                                        </DataTrigger>
                                                    </Style.Triggers>
                                                </Style>
                                            </Button.Style>                                        
                                        </Button>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
    
                        </GridView.Columns>
    
                    </GridView>
                </ListView.View>
            </ListView>
