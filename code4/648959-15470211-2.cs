     <Window x:Class="ComboboxSelectedItem.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:viewModel="clr-namespace:ComboboxSelectedItem.ViewModels"
        Title="MainWindow" Height="350" Width="525">
    <Grid Name="mainGrid">
        
        <Grid.DataContext>
            <viewModel:MainViewModel />
        </Grid.DataContext>
        
        <TabControl
            ItemsSource="{Binding Tabs, Mode=TwoWay}"
            SelectedItem="{Binding SelectedTab}">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Header}" Margin="0 0 20 0"/>
                    </StackPanel>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <!--Content section-->
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <Grid>
                        <StackPanel Orientation="Vertical">
                            <TextBlock
                                Text="{Binding Content}" />
                            <ComboBox
                                ItemsSource="{Binding StatusList}"
                                SelectedItem="{Binding SelectedStatus}" />
                        </StackPanel>
                        
                    </Grid>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
    </Grid>
    </Window>
