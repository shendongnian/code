    <ListView.View>
                            <GridView AllowsColumnReorder="False" x:Name="gvCurDocFields">
                                <GridViewColumn Width="120">
                                    <GridViewColumnHeader Content="Field" />   
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                            <TextBlock TextWrapping="NoWrap" TextTrimming="CharacterEllipsis" Text="{Binding Path=FieldDefApplied.FieldDef.DispName, Mode=OneWay}"  />
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>
                                <GridViewColumn>
                                    <GridViewColumnHeader Content="Value" />
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                            <TextBlock TextAlignment="Left" Margin="0" TextWrapping="NoWrap" TextTrimming="CharacterEllipsis" Text="{Binding Path=DispValue, Mode=OneWay}" />
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>
                            </GridView>
                        </ListView.View>
