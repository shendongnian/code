    <Window x:Class="WpfApplication8.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="233" Width="405" Name="UI">
        <Grid DataContext="{Binding ElementName=UI}">
            <ListView ItemsSource="{Binding Processes}" >
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Process" Width="200"  >
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <StackPanel>
                                        <TreeView BorderThickness="0" ItemsSource="{Binding Processes}" >
                                            <TreeView.ItemTemplate>
                                                <HierarchicalDataTemplate ItemsSource="{Binding Processes}">
                                                    <TextBlock Text="{Binding Name}" />
                                                </HierarchicalDataTemplate>
                                            </TreeView.ItemTemplate>
                                        </TreeView>
                                    </StackPanel>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="CPU" >
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding CpuUsage, StringFormat={}{0} %}" TextAlignment="Right" />
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Memory" >
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding MemUsage, StringFormat={}{0} MB}" TextAlignment="Right" />
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Setter Property="VerticalContentAlignment" Value="Top" />
                    </Style>
                </ListView.ItemContainerStyle>
            </ListView>
        </Grid>
    </Window>
