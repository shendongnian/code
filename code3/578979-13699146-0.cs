    <StackPanel Name="stpData">
        <StackPanel.BindingGroup>
            <BindingGroup Name="bindingGroup"/>
        </StackPanel.BindingGroup>
    
        <!-- This works nice! -->
        <TextBox Text="{Binding Path=name}" />
        <CheckBox IsChecked="{Binding Path=enable}" />
    
        <!-- Now this work nice as well! -->
        <ListView Name="lvBools" ItemsSource="{Binding Path=myList}">
            <ListView.View>
                <GridView>
                    <GridViewColumn>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <CheckBox IsChecked="{Binding bools, BindingGroupName=bindingGroup}" />
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
    </StackPanel>
