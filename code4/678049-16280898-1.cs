    <Window x:Class="WpfApplication21.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
        
            <Style x:Key="lvStyle" TargetType="{x:Type ListView}" >
                <Setter Property="ListView.ItemsSource" Value="{Binding}"/>
                <Setter Property="ListView.View">
                    <Setter.Value>
                        <GridView>
                            <GridViewColumn Header="Name">
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Name}"/>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                            <GridViewColumn Header="Date">
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Date}"/>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                            <GridViewColumn Header="Desc">
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Desc}"/>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                        </GridView>
                    </Setter.Value>
                </Setter>
            </Style>
        </Window.Resources>
        <Grid>
            <ListView x:Name="ListView1"
                      Style="{DynamicResource lvStyle}"
                      VirtualizingPanel.IsVirtualizing="True"
                      VirtualizingPanel.IsVirtualizingWhenGrouping="True">
                <ListView.GroupStyle>
                    <GroupStyle>
                        <GroupStyle.ContainerStyle>
                            <Style TargetType="{x:Type GroupItem}">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate TargetType="{x:Type GroupItem}">
                                            <Expander IsExpanded="True">
                                                <DockPanel>
                                                    <Border DockPanel.Dock="Top">
                                                        <TextBlock x:Name="groupItem"
                                                                    Text="{Binding ItemCount, StringFormat={}({0} Results)}"></TextBlock>
                                                    </Border>
                                                    <ItemsPresenter x:Name="groupItemPresenter" DockPanel.Dock="Bottom"></ItemsPresenter>
                                                </DockPanel>
                                            </Expander>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </GroupStyle.ContainerStyle>
                    </GroupStyle>
                </ListView.GroupStyle>
            </ListView>
        </Grid>
    </Window>
