    <Window x:Class="Application.MainWindowView"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindowView" Height="300" Width="300"
            x:Name="MainWindow">
        <Window.Resources>
            <ResourceDictionary>
                <ContextMenu x:Key="FooContextMenu">
                    <MenuItem Header="Help" Command="{Binding PlacementTarget.Tag.HelpExecuted, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
                </ContextMenu>
            </ResourceDictionary>
        </Window.Resources>
        <Grid>
            <TabControl ItemsSource="{Binding FooViewModels}" x:Name="MainTabs">
                <TabControl.ContentTemplate>
                    <DataTemplate>
                        <DataGrid ContextMenu="{DynamicResource FooContextMenu}" Tag="{Binding}" />
                    </DataTemplate>
                </TabControl.ContentTemplate>
            </TabControl>
        </Grid>
    </Window>
