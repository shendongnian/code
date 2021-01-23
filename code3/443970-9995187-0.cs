    <Style x:Key="NewDataPointStyle" TargetType="chartingToolkit:BarDataPoint">
    <Setter Property="Background" Value="SteelBlue" />
    <Setter Property="IsTabStop" Value="False" />
    <Setter Property="BorderBrush" Value="#FF686868" />
    <Setter Property="Width" Value="20" />
    <Setter Property="Height" Value="20" />
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="chartingToolkit:BarDataPoint">
                <Grid x:Name="Root" Opacity="1">
                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0:0:0.1" />
                            </VisualStateGroup.Transitions>
                            <VisualState x:Name="Normal" />
                            <VisualState x:Name="MouseOver">
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="MouseOverHighlight" Storyboard.TargetProperty="(UIElement.Opacity)">
                                        <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0.3" />
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
                        </VisualStateGroup>
                        <VisualStateGroup x:Name="SelectionStates">
                            <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0:0:0.1" />
                            </VisualStateGroup.Transitions>
                            <VisualState x:Name="Unselected" />
                            <VisualState x:Name="Selected">
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectionHighlight" Storyboard.TargetProperty="(UIElement.Opacity)">
                                        <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0.185" />
                                    </DoubleAnimationUsingKeyFrames>
                                    <ColorAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectionHighlight" Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)">
                                        <SplineColorKeyFrame KeyTime="00:00:00" Value="#FF8A8A8A" />
                                    </ColorAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
                        </VisualStateGroup>
                        <VisualStateGroup x:Name="RevealStates">
                            <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0:0:0.5" />
                            </VisualStateGroup.Transitions>
                            <VisualState x:Name="Shown">
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="Root" Storyboard.TargetProperty="(UIElement.Opacity)">
                                        <SplineDoubleKeyFrame KeyTime="00:00:00" Value="1" />
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="Hidden">
                                <Storyboard>
                                    <DoubleAnimation Duration="0" Storyboard.TargetName="Root" Storyboard.TargetProperty="Opacity" To="0" />
                                </Storyboard>
                            </VisualState>
                        </VisualStateGroup>
                    </VisualStateManager.VisualStateGroups>
                    <ToolTipService.ToolTip>
                        <ContentControl Content="{Binding Path=Event_Description}" />
                    </ToolTipService.ToolTip>
                            <StackPanel Orientation="Horizontal"
                                    Background="{TemplateBinding Background}">
                            </StackPanel>
                    </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
