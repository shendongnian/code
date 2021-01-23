    <Window x:Class="MiscSamples.WhackAMole"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="WhackAMole" Height="300" Width="300">
        <ItemsControl ItemsSource="{Binding Moles}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <UniformGrid Rows="3" Columns="3" IsItemsHost="True"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Image x:Name="Mole" Height="0" Width="100" 
                           Source="/Images/Mole.Png"
                           Stretch="Fill"
                           VerticalAlignment="Bottom"/>
                    <DataTemplate.Triggers>
                        <DataTrigger Binding="{Binding IsUp}" Value="True">
                            <DataTrigger.EnterActions>
                                <BeginStoryboard>
                                    <Storyboard TargetName="Mole">
                                        <DoubleAnimation Storyboard.TargetProperty="Height" 
                                                         From="0" To="77"
                                                         Duration="00:00:00.3"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </DataTrigger.EnterActions>
                            <DataTrigger.ExitActions>
                                <BeginStoryboard>
                                    <Storyboard TargetName="Mole">
                                        <DoubleAnimation Storyboard.TargetProperty="Height"
                                                         From="77" To="0"
                                                         Duration="00:00:00.3"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </DataTrigger.ExitActions>
                        </DataTrigger>
                    </DataTemplate.Triggers>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Window>
