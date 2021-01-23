    <Window x:Class="DataGridSelectionActive.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:DataGridSelectionActive"
            Title="MainWindow" Height="350" Width="525">
        
        <!-- People is just an ObservableCollection derived class. -->
        <Window.DataContext>
            <local:People/>
        </Window.DataContext>
    
        <Window.Resources>
    
            <ContextMenu x:Key="dataGridContextMenu">
                <MenuItem Header="Some context menu item"/>
            </ContextMenu>
    
            <Style TargetType="{x:Type DataGridCell}">
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                        <Setter Property="BorderBrush" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                    </Trigger>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding IsSelected, RelativeSource={RelativeSource Self}}" Value="True"/>
                            <Condition Binding="{Binding IsKeyboardFocusWithin, RelativeSource={RelativeSource AncestorType=DataGrid}}" Value="False"/>
                        </MultiDataTrigger.Conditions>
                        <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
                        <Setter Property="BorderBrush" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
                    </MultiDataTrigger>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding IsSelected, RelativeSource={RelativeSource Self}}" Value="True"/>
                            <Condition Binding="{Binding ContextMenu.IsOpen, RelativeSource={RelativeSource AncestorType=DataGrid}}" Value="True"/>
                        </MultiDataTrigger.Conditions>
                        <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                        <Setter Property="BorderBrush" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
            
        </Window.Resources>
        
        <DockPanel>
            <!-- Added button for testing keyboard focus. -->
            <Button DockPanel.Dock="Top" Content="Click me"/>
            <DataGrid ItemsSource="{Binding}" ContextMenu="{StaticResource dataGridContextMenu}"/>
        </DockPanel>
        
    </Window>
