    <Button Margin="0,12,401,276" Click="Button_Click">Button</Button>
            <ListView x:Name="yourListView" ItemsSource="{Binding Things}" SelectedItem="{Binding SelectedThing}" Margin="0,41,0,0">
                <ListView.View>
                    <GridView>
                        <GridView.Columns>
                            <GridViewColumn Header="Check"  Width="250">
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <CheckBox x:Name="myCBox" Content="{Binding ThingName}"></CheckBox>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                        </GridView.Columns>
                    </GridView>
                </ListView.View>
            </ListView> 
