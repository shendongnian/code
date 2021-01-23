    <GridViewColumn Width="30" Header="">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Button Content=" X " IsEnabled="{Binding RelativeSource={RelativeSource AncestorType={x:Type ListViewItem}}, Path=IsSelected}" />
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
