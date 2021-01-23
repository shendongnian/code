    <GridViewColumn Header="Display On Search">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <CheckBox Visibility="{Binding sourceProp, Converter={StaticResource myStringToVisibilityConverter}}" />
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>                            
                        </GridViewColumn>
