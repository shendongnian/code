    <UserControl x:Name="TheUserControl">
        <ListView>
            <GridView>
                <GridViewColumn Header="Type" Width="170">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding ElementName=TheUserControl, Path=AppointmentTypes}"
                                      SelectedItem="{Binding Path=Type}"/>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView>
    </UserControl>
