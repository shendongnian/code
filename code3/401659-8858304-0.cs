    <ComboBox x:Name="cb" ItemsSource="{Binding Persons}">
                    <ComboBox.ItemTemplate>
                        <DataTemplate>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="50" />
                                    <ColumnDefinition Width="50" />
                                </Grid.ColumnDefinitions>
                                <TextBlock Grid.Column="0" Text="{Binding Name}" />
                                <TextBlock Grid.Column="1" Text="{Binding Age}" />
                            </Grid>
                        </DataTemplate>
                    </ComboBox.ItemTemplate>
                </ComboBox>
