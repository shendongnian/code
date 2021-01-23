    <Window x:Name="window" 
        x:Class="stackoverflowTreeview.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:t="clr-namespace:System;assembly=mscorlib"
        xmlns:this="clr-namespace:stackoverflowTreeview"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <this:testConv x:Key="testConv"/>
        <Grid x:Key="IHerpTemplate">
            <TextBlock Text="{Binding Name}"/>
        </Grid>
        
        <Style TargetType="TreeView">
            <Setter Property="ItemTemplate">
                <Setter.Value>
                    <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                        <ContentControl>
                            <ContentControl.Style>
                                <Style>
                                    <Setter Property="ContentControl.Content">
                                        <Setter.Value>
                                            <TextBlock Text="{Binding Name}"/>
                                        </Setter.Value>
                                    </Setter>
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=TreeViewItem}}" Value="True">
                                            <Setter Property="ContentControl.Content">
                                                <Setter.Value>
                                                    <ContentControl Content="{Binding}">
                                                        <ContentControl.Resources>
                                                            <DataTemplate DataType="{x:Type this:Herp}">
                                                                <TextBlock Text="{Binding Name}"/>
                                                            </DataTemplate>
                                                            <DataTemplate DataType="{x:Type this:Derp}">
                                                                <StackPanel>
                                                                    <TextBlock Text="{Binding Name}"/>
                                                                    <TextBlock Text="{Binding Value}"/>
                                                                </StackPanel>
                                                            </DataTemplate>
                                                        </ContentControl.Resources>
                                                    </ContentControl>
                                                </Setter.Value>
                                            </Setter>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </ContentControl.Style>
                        </ContentControl>
                    </HierarchicalDataTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        
    </Window.Resources>
        <Grid>
            <TreeView Name="m_kTest" ItemsSource="{Binding Data, ElementName=window}">
            
            </TreeView>
        </Grid>
    </Window>
