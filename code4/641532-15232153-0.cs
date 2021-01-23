    <Window x:Class="WpfApplication4.Window13"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="Window13" Height="300" Width="300">
        <ItemsControl ItemsSource="{Binding}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <UniformGrid Rows="8" Columns="6" IsItemsHost="True"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <DataTemplate.Resources>
                        <Storyboard x:Key="ToBlack" TargetName="RctFill" Duration="00:00:00.5">
                            <ColorAnimation From="White" To="Black" Duration="00:00:00.5" Storyboard.TargetProperty="Color"/>
                        </Storyboard>
                        <Storyboard x:Key="ToWhite" TargetName="RctFill" Duration="00:00:00.5">
                            <ColorAnimation From="Black" To="White" Duration="00:00:00.5"  Storyboard.TargetProperty="Color"/>
                        </Storyboard>
                    </DataTemplate.Resources>
                    <Button Command="{Binding ToggleCommand}">
                        <Button.Template>
                            <ControlTemplate>
                                <Rectangle Stroke="Black" StrokeThickness="1" x:Name="Rct">
                                    <Rectangle.Fill>
                                        <SolidColorBrush Color="White" x:Name="RctFill"/>
                                    </Rectangle.Fill>
                                </Rectangle>
                                <ControlTemplate.Triggers>
                                    <DataTrigger Binding="{Binding State}" Value="True">
                                        <DataTrigger.EnterActions>
                                            <BeginStoryboard Storyboard="{StaticResource ToBlack}"/>
                                        </DataTrigger.EnterActions>
                                        <DataTrigger.ExitActions>
                                            <BeginStoryboard Storyboard="{StaticResource ToWhite}"/>
                                        </DataTrigger.ExitActions>
                                    </DataTrigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Button.Template>
                    </Button>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Window>
