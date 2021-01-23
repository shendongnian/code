    <TreeView>
        <TreeView.ItemContainerStyle>
            <Style TargetType="TreeViewItem">
                <!-- set the headers content to stretch -->
                <Setter Property="Control.HorizontalContentAlignment" Value="Stretch"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="TreeViewItem" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:s="clr-namespace:System;assembly=mscorlib" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto" MinWidth="19" />
                                    <ColumnDefinition Width="Auto" />
                                    <ColumnDefinition Width="*" />
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto" />
                                    <RowDefinition />
                                </Grid.RowDefinitions>
                                <ToggleButton IsChecked="False" ClickMode="Press" Name="Expander">
                                    <ToggleButton.Style>
                                        <Style TargetType="ToggleButton">
                                            <Style.Resources>
                                                <ResourceDictionary />
                                            </Style.Resources>
                                            <Setter Property="UIElement.Focusable">
                                                <Setter.Value>
                                                    <s:Boolean>False</s:Boolean>
                                                </Setter.Value>
                                            </Setter>
                                            <Setter Property="FrameworkElement.Width">
                                                <Setter.Value>
                                                    <s:Double>16</s:Double>
                                                </Setter.Value>
                                            </Setter>
                                            <Setter Property="FrameworkElement.Height">
                                                <Setter.Value>
                                                    <s:Double>16</s:Double>
                                                </Setter.Value>
                                            </Setter>
                                            <Setter Property="Control.Template">
                                                <Setter.Value>
                                                    <ControlTemplate TargetType="ToggleButton">
                                                        <Border Padding="5,5,5,5" Background="#00FFFFFF" Width="16" Height="16">
                                                            <Path Fill="#00FFFFFF" Stroke="#FF989898" Name="ExpandPath">
                                                                <Path.Data>
                                                                    <PathGeometry Figures="M0,0L0,6L6,0z" />
                                                                </Path.Data>
                                                                <Path.RenderTransform>
                                                                    <RotateTransform Angle="135" CenterX="3" CenterY="3" />
                                                                </Path.RenderTransform>
                                                            </Path>
                                                        </Border>
                                                        <ControlTemplate.Triggers>
                                                            <Trigger Property="UIElement.IsMouseOver">
                                                                <Setter Property="Shape.Stroke" TargetName="ExpandPath">
                                                                    <Setter.Value>
                                                                        <SolidColorBrush>#FF1BBBFA</SolidColorBrush>
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Setter Property="Shape.Fill" TargetName="ExpandPath">
                                                                    <Setter.Value>
                                                                        <SolidColorBrush>#00FFFFFF</SolidColorBrush>
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Trigger.Value>
                                                                    <s:Boolean>True</s:Boolean>
                                                                </Trigger.Value>
                                                            </Trigger>
                                                            <Trigger Property="ToggleButton.IsChecked">
                                                                <Setter Property="UIElement.RenderTransform" TargetName="ExpandPath">
                                                                    <Setter.Value>
                                                                        <RotateTransform Angle="180" CenterX="3" CenterY="3" />
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Setter Property="Shape.Fill" TargetName="ExpandPath">
                                                                    <Setter.Value>
                                                                        <SolidColorBrush>#FF595959</SolidColorBrush>
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Setter Property="Shape.Stroke" TargetName="ExpandPath">
                                                                    <Setter.Value>
                                                                        <SolidColorBrush>#FF262626</SolidColorBrush>
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Trigger.Value>
                                                                    <s:Boolean>True</s:Boolean>
                                                                </Trigger.Value>
                                                            </Trigger>
                                                        </ControlTemplate.Triggers>
                                                    </ControlTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </Style>
                                    </ToggleButton.Style>
                                </ToggleButton>
                                <!-- other problem was here set the Borders ColumnSpan to 2 -->
                                <Border BorderThickness="{TemplateBinding Border.BorderThickness}" Padding="{TemplateBinding Control.Padding}" BorderBrush="{TemplateBinding Border.BorderBrush}" Background="{TemplateBinding Panel.Background}" Name="Bd" SnapsToDevicePixels="True" Grid.Column="1" HorizontalAlignment="Stretch" Grid.ColumnSpan="2" >
                                    <ContentPresenter Content="{TemplateBinding HeaderedContentControl.Header}" ContentTemplate="{TemplateBinding HeaderedContentControl.HeaderTemplate}" ContentStringFormat="{TemplateBinding HeaderedItemsControl.HeaderStringFormat}" ContentSource="Header" Name="PART_Header" HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" />
                                </Border>
                                <ItemsPresenter Name="ItemsHost" Grid.Column="1" Grid.Row="1" Grid.ColumnSpan="2" />
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="TreeViewItem.IsExpanded">
                                    <Setter Property="UIElement.Visibility" TargetName="ItemsHost">
                                        <Setter.Value>
                                            <x:Static Member="Visibility.Collapsed" />
                                        </Setter.Value>
                                    </Setter>
                                    <Trigger.Value>
                                        <s:Boolean>False</s:Boolean>
                                    </Trigger.Value>
                                </Trigger>
                                <Trigger Property="ItemsControl.HasItems">
                                    <Setter Property="UIElement.Visibility" TargetName="Expander">
                                        <Setter.Value>
                                            <x:Static Member="Visibility.Hidden" />
                                        </Setter.Value>
                                    </Setter>
                                    <Trigger.Value>
                                        <s:Boolean>False</s:Boolean>
                                    </Trigger.Value>
                                </Trigger>
                                <Trigger Property="TreeViewItem.IsSelected">
                                    <Setter Property="Panel.Background" TargetName="Bd">
                                        <Setter.Value>
                                            <DynamicResource ResourceKey="{x:Static SystemColors.HighlightBrushKey}" />
                                        </Setter.Value>
                                    </Setter>
                                    <Setter Property="TextElement.Foreground">
                                        <Setter.Value>
                                            <DynamicResource ResourceKey="{x:Static SystemColors.HighlightTextBrushKey}" />
                                        </Setter.Value>
                                    </Setter>
                                    <Trigger.Value>
                                        <s:Boolean>True</s:Boolean>
                                    </Trigger.Value>
                                </Trigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="TreeViewItem.IsSelected">
                                            <Condition.Value>
                                                <s:Boolean>True</s:Boolean>
                                            </Condition.Value>
                                        </Condition>
                                        <Condition Property="Selector.IsSelectionActive">
                                            <Condition.Value>
                                                <s:Boolean>False</s:Boolean>
                                            </Condition.Value>
                                        </Condition>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Panel.Background" TargetName="Bd">
                                        <Setter.Value>
                                            <DynamicResource ResourceKey="{x:Static SystemColors.ControlBrushKey}" />
                                        </Setter.Value>
                                    </Setter>
                                    <Setter Property="TextElement.Foreground">
                                        <Setter.Value>
                                            <DynamicResource ResourceKey="{x:Static SystemColors.ControlTextBrushKey}" />
                                        </Setter.Value>
                                    </Setter>
                                </MultiTrigger>
                                <Trigger Property="UIElement.IsEnabled">
                                    <Setter Property="TextElement.Foreground">
                                        <Setter.Value>
                                            <DynamicResource ResourceKey="{x:Static SystemColors.GrayTextBrushKey}" />
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
        </TreeView.ItemContainerStyle>
        <RichTextBox HorizontalAlignment="Stretch" HorizontalContentAlignment="Stretch">
            <FlowDocument>
                <Paragraph>
                    <Run>
                        Hello
                    </Run>
                </Paragraph>
            </FlowDocument>
        </RichTextBox>
    </TreeView>
