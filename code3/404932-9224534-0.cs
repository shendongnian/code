    <Grid Name="BaseGrid">
        <Grid.Resources>
            <XmlDataProvider x:Name="ScenesXmlName" x:Key="ScenesXml" XPath="scenari-list/scenario" Source="myPath"/>
        </Grid.Resources>
        <ComboBox Grid.Column="0" Grid.Row="1" Name="ScenariCombo" IsSynchronizedWithCurrentItem="True" ItemsSource="{Binding Source={StaticResource ScenesXml}}" DisplayMemberPath="@name"/>
    <StackPanel>
    <ListBox Name="LightsList" ItemsSource="{Binding Source={StaticResource ScenesXml}, XPath=lights/lights-group}">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <Expander Header="{Binding XPath=@name}" HorizontalAlignment="Stretch">
                                        <ListBox IsSynchronizedWithCurrentItem="True" ItemsSource="{Binding XPath=lights-item}">
                                            <ListBox.ItemTemplate>
                                                <DataTemplate>
                                                    <Grid>
                                                        <Grid.ColumnDefinitions>
                                                            <ColumnDefinition Width="*" />
                                                            <ColumnDefinition Width="150" />
                                                        </Grid.ColumnDefinitions>
                                                        <Label Content="{Binding XPath=@name}" Grid.Column="0"/>
                                                        <CheckBox Grid.Column="1" IsChecked="{Binding XPath=., Converter={StaticResource myStateToBoolConverter}}"/>
                                                    </Grid>
                                                </DataTemplate>
                                            </ListBox.ItemTemplate>
                                        </ListBox>
                                    </Expander>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
        </StackPanel>
    </Grid>
