          <GridViewColumn Header="None">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <CheckBox Width="50"
                                          Height="50"
                                          IsChecked="{Binding RelativeSource={RelativeSource AncestorType={x:Type ListViewItem}},
                                                              Path=IsSelected,Mode=TwoWay}" />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
