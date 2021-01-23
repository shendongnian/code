    <Window x:Class="WpfApplication2.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" 
            SizeToContent="WidthAndHeight">
        <Grid>
            <ListView ItemsSource="{Binding}">
                <ListView.Resources>
                    <DataTemplate x:Key="IsBossTemplate">
                        <Rectangle Fill="Red" Width="50" Height="20" x:Name="IsBossMark"/>
                        <DataTemplate.Triggers>
                            <DataTrigger Value="True" Binding="{Binding IsBoss}">
                                <Setter TargetName="IsBossMark" Property="Fill" Value="DarkRed"/>
                            </DataTrigger>
                        </DataTemplate.Triggers>
                    </DataTemplate>
                </ListView.Resources>
                <ListView.ItemContainerStyle>
                    <Style TargetType="{x:Type ListViewItem}">
                        <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                    </Style>
                </ListView.ItemContainerStyle>
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Character name"
                                        DisplayMemberBinding="{Binding Name}"/>
                        <GridViewColumn Header="Is boss" 
                                        CellTemplate="{StaticResource IsBossTemplate}"/>
                    </GridView>
                </ListView.View>
            </ListView>
        </Grid>
    </Window>
