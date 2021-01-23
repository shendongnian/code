    <Window x:Class="WpfApplication6.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="35"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <Button Content="Add element" Command="{Binding AddElementCommand}" Grid.Row="0"/>
            
            
            <ListView Grid.Row="1"
                      Margin="10"
                      ItemsSource="{Binding YourGridList, UpdateSourceTrigger=PropertyChanged}"
                      MaxHeight="300">
                <ListView.View>
                    <GridView>
                        <GridView.Columns>
                            <GridViewColumn Width="Auto">
                                <GridViewColumn.Header>
                                    <GridViewColumnHeader Content="Element 1" HorizontalContentAlignment="Left" />
                                </GridViewColumn.Header>
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Element1}"/>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                            <GridViewColumn Width="Auto">
                                <GridViewColumn.Header>
                                    <GridViewColumnHeader Content="Element 2" HorizontalContentAlignment="Left" />
                                </GridViewColumn.Header>
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Element2}"/>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                            <GridViewColumn Width="Auto" >
                                <GridViewColumn.Header>
                                    <GridViewColumnHeader Content="Element 3" HorizontalContentAlignment="Left" />
                                </GridViewColumn.Header>
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Element3}"/>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                        </GridView.Columns>
                    </GridView>
                </ListView.View>
            </ListView>
        </Grid>
    </Grid>
