    <Page
    x:Class="StackOverflowMultiButton.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:StackOverflowMultiButton"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">
    <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
        <StackPanel Orientation="Horizontal">
        <StackPanel>
                <ToggleButton x:Name="ToggleButton1" IsChecked="{Binding tbt1_isChecked, Mode=TwoWay}"/>
                <ToggleButton x:Name="ToggleButton2" IsChecked="{Binding tbt2_isChecked, Mode=TwoWay}"/>
                <ToggleButton x:Name="ToggleButton3" IsChecked="{Binding tbt3_isChecked, Mode=TwoWay}"/>
                <ToggleButton x:Name="ToggleButton4" IsChecked="{Binding tbt4_isChecked, Mode=TwoWay}"/>
        </StackPanel>
        <StackPanel>
                <ToggleButton x:Name="ToggleButton5" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton6" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton7" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton8" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton9" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton10" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton11" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton12" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton13" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton14" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton15" IsEnabled="{Binding CommonIsEnabled}"/>
                <ToggleButton x:Name="ToggleButton16" IsEnabled="{Binding CommonIsEnabled}"/>
        </StackPanel>
            
        </StackPanel>
    </Grid>
