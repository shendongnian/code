        <?xml version="1.0" encoding="utf-16"?>
        <ControlTemplate
            TargetType="DataGrid"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:s="clr-namespace:System;assembly=mscorlib">
            <Border
                BorderThickness="0,0,0,0"
                Padding="0,0,0,0"
                BorderBrush="{x:Null}"
                Background="{x:Null}"
                SnapsToDevicePixels="True">
                <ScrollViewer
                    Name="DG_ScrollViewer"
                    Focusable="False">
                    <ScrollViewer.Template>
                        <ControlTemplate
                            TargetType="ScrollViewer">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition
                                        Width="Auto" />
                                    <ColumnDefinition
                                        Width="*" />
                                    <ColumnDefinition
                                        Width="Auto" />
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition
                                        Height="Auto" />
                                    <RowDefinition
                                        Height="*" />
                                    <RowDefinition
                                        Height="Auto" />
                                </Grid.RowDefinitions>
                                <Button
                                    Command="SelectAll"
                                    Width="Auto"
                                    Visibility="Visible"
                                    Focusable="False">
                                    <Button.Style>
                                        <Style
                                            TargetType="Button">
                                            <Style.Resources>
                                                <ResourceDictionary />
                                            </Style.Resources>
                                            <Setter
                                                Property="Control.Template">
                                                <Setter.Value>
                                                    <ControlTemplate
                                                        TargetType="Button">
                                                        <Grid>
                                                            <Rectangle
                                                                Fill="#FFF0F0F0"
                                                                Name="Border"
                                                                SnapsToDevicePixels="True" />
                                                            <Polygon
                                                                Points="0,10 10,10 10,0"
                                                                Stretch="Uniform"
                                                                Fill="#FF000000"
                                                                Name="Arrow"
                                                                Margin="8,8,3,3"
                                                                HorizontalAlignment="Right"
                                                                VerticalAlignment="Bottom"
                                                                Opacity="0.15" />
                                                        </Grid>
                                                        <ControlTemplate.Triggers>
                                                            <Trigger
                                                                Property="UIElement.IsMouseOver">
                                                                <Setter
                                                                    Property="Shape.Stroke"
                                                                    TargetName="Border">
                                                                    <Setter.Value>
                                                                        <DynamicResource
                                                                            ResourceKey="{x:Static SystemColors.ControlDarkBrushKey}" />
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Trigger.Value>
                                                                    <s:Boolean>True</s:Boolean>
                                                                </Trigger.Value>
                                                            </Trigger>
                                                            <Trigger
                                                                Property="ButtonBase.IsPressed">
                                                                <Setter
                                                                    Property="Shape.Fill"
                                                                    TargetName="Border">
                                                                    <Setter.Value>
                                                                        <DynamicResource
                                                                            ResourceKey="{x:Static SystemColors.ControlDarkBrushKey}" />
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Trigger.Value>
                                                                    <s:Boolean>True</s:Boolean>
                                                                </Trigger.Value>
                                                            </Trigger>
                                                            <Trigger
                                                                Property="UIElement.IsEnabled">
                                                                <Setter
                                                                    Property="UIElement.Visibility"
                                                                    TargetName="Arrow">
                                                                    <Setter.Value>
                                                                        <x:Static
                                                                            Member="Visibility.Collapsed" />
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Trigger.Value>
                                                                    <s:Boolean>False</s:Boolean>
                                                                </Trigger.Value>
                                                            </Trigger>
                                                        </ControlTemplate.Triggers>
                                                    </ControlTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </Style>
                                    </Button.Style>
                                </Button>
                                <DataGridColumnHeadersPresenter
                                    Name="PART_ColumnHeadersPresenter"
                                    Visibility="Visible"
                                    Grid.Column="1" />
                                <ScrollContentPresenter
                                    CanContentScroll="False"
                                    CanHorizontallyScroll="False"
                                    CanVerticallyScroll="False"
                                    Content="{x:Null}"
                                    ContentTemplate="{x:Null}"
                                    ContentStringFormat="{x:Null}"
                                    Name="PART_ScrollContentPresenter"
                                    Grid.Row="1"
                                    Grid.ColumnSpan="2" />
                                <ScrollBar
                                    Orientation="Vertical"
                                    Maximum="1"
                                    Value="0"
                                    Name="PART_VerticalScrollBar"
                                    Visibility="Visible"
                                    Grid.Column="2"
                                    Grid.Row="1" />
                                <Grid
                                    Grid.Column="1"
                                    Grid.Row="2">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition
                                            Width="*" />
                                        <ColumnDefinition
                                            Width="*" />
                                    </Grid.ColumnDefinitions>
                                    <ScrollBar
                                        Orientation="Horizontal"
                                        Maximum="1"
                                        Value="0"
                                        Name="PART_HorizontalScrollBar"
                                        Visibility="Visible"
                                        Grid.Column="1" />
                                </Grid>
                            </Grid>
                        </ControlTemplate>
                    </ScrollViewer.Template>
                    <ItemsPresenter
                        SnapsToDevicePixels="False" />
                </ScrollViewer>
            </Border>
        </ControlTemplate>
