    <Style TargetType="CheckBox" x:Key="DefaultCheckBoxStyle">
            <Setter Property="FontFamily" Value="{StaticResource ContentFontFamily}"/>
            <Setter Property="FontSize" Value="{StaticResource ContentFontSize}"/>
            <Setter Property="Background" Value="{StaticResource NormalBrush}"/>
            <Setter Property="Foreground" Value="{StaticResource TextContentBrush}"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="VerticalContentAlignment" Value="Top"/>
            <Setter Property="Padding" Value="4,1,0,0"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Value="{StaticResource NormalBorderBrush}" Property="BorderBrush"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="CheckBox">
                        <Grid x:Name="grid" RenderTransformOrigin="0.5,0.5">
                            <Grid.RenderTransform>
                                <TransformGroup>
                                    <ScaleTransform/>
                                    <SkewTransform/>
                                    <RotateTransform/>
                                    <TranslateTransform/>
                                </TransformGroup>
                            </Grid.RenderTransform>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition From="Normal" GeneratedDuration="0:0:0.01" To="MouseOver">
                                            <VisualTransition.GeneratedEasingFunction>
                                                <ExponentialEase EasingMode="EaseIn" Exponent="7"/>
                                            </VisualTransition.GeneratedEasingFunction>
                                        </VisualTransition>
                                        <VisualTransition From="MouseOver" GeneratedDuration="0:0:0.1" To="Normal">
                                            <VisualTransition.GeneratedEasingFunction>
                                                <CircleEase EasingMode="EaseIn"/>
                                            </VisualTransition.GeneratedEasingFunction>
                                        </VisualTransition>
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Normal"/>
                                    <VisualState x:Name="MouseOver">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="MouseOverRectangleFill" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="1.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Pressed">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="PressedBorder" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="1.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)" Storyboard.TargetName="grid">
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="1.05"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" Storyboard.TargetName="grid">
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="1.05"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="contentPresenter" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="0.3"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="DisabledVisualElement" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="1.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="CheckStates">
                                    <VisualState x:Name="Checked">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="CheckIcon">
                                                <SplineDoubleKeyFrame KeyTime="0" Value="1"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="CheckedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="0.6"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Unchecked"/>
                                    <VisualState x:Name="Indeterminate">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="IndeterminateIcon">
                                                <SplineDoubleKeyFrame KeyTime="0" Value="1"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="IndeterminateRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="0.6"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="FocusStates">
                                    <VisualState x:Name="Focused">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="Opacity" Storyboard.TargetName="ContentFocusVisualElement">
                                                <SplineDoubleKeyFrame KeyTime="0" Value="1"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Unfocused"/>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="ValidationStates">
                                    <VisualState x:Name="Valid"/>
                                    <VisualState x:Name="InvalidUnfocused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="InvalidFocused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" Storyboard.TargetName="validationTooltip">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <System:Boolean>True</System:Boolean>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"/>
                                <ColumnDefinition Width="21"/>
                            </Grid.ColumnDefinitions>
                            <Grid HorizontalAlignment="Right" VerticalAlignment="Top" Grid.Column="1" Margin="5,0,0,0">
                                <Grid Width="16" Height="16">
                                    <Rectangle x:Name="Background" Fill="{StaticResource BlankBackgroundBrush}" StrokeThickness="{TemplateBinding BorderThickness}" Stroke="{StaticResource BaseBrush7}" />
                                    <Rectangle x:Name="BackgroundInner" Fill="{TemplateBinding Background}" Margin="1" StrokeThickness="{TemplateBinding BorderThickness}" Stroke="{TemplateBinding BorderBrush}"/>
                                    <Rectangle x:Name="MouseOverRectangleFill" Fill="{StaticResource MouseOverBrush}" StrokeThickness="2" Opacity="0" Margin="3"/>
                                    <Rectangle x:Name="MouseOverRectangle" StrokeThickness="2" Stroke="{StaticResource MouseOverBrush}" Opacity="0"/>
                                    <Border x:Name="PressedBorder" BorderThickness="1" BorderBrush="{StaticResource MouseOverBrush}" Opacity="0" />
                                    <Rectangle x:Name="ContentFocusVisualElement"  StrokeThickness="1" IsHitTestVisible="false" Opacity="0" Stroke="{StaticResource FocusedBrush}" />
                                    <Rectangle x:Name="DisabledVisualElement" Fill="{StaticResource DisabledBackgroundBrush}" Stroke="{StaticResource DisabledBackgroundBrush}" Opacity="0" RadiusY="1" RadiusX="1" />
                                    <Rectangle x:Name="CheckedRectangle" StrokeThickness="0.5" Stroke="{StaticResource BaseBrush4}" Opacity="0" RadiusX="0.5" RadiusY="0.5"/>
                                    <Path x:Name="CheckIcon" Data="M335.69366,107.11728 L339,111.375 347.09859,99.975309" HorizontalAlignment="Center" Stretch="Fill" Stroke="{StaticResource BaseBrush4}" UseLayoutRounding="False" VerticalAlignment="Center" StrokeThickness="2" StrokeStartLineCap="Round" StrokeEndLineCap="Round" Margin="3.5" Opacity="0"/>
    
                                    <Rectangle x:Name="IndeterminateRectangle" StrokeThickness="2" Stroke="{StaticResource BaseBrush4}" Opacity="0"/>
                                    <Rectangle x:Name="IndeterminateIcon" Fill="{StaticResource BaseBrush3}" Height="2" Opacity="0" Width="6"/>
                                    <Border x:Name="ValidationErrorElement" BorderBrush="{StaticResource ControlsValidationBrush}" BorderThickness="1" CornerRadius="1" Margin="1" ToolTipService.PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}" Visibility="Collapsed">
                                        <ToolTipService.ToolTip>
                                            <ToolTip x:Name="validationTooltip" DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Placement="Right" PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}" Template="{StaticResource ValidationToolTipTemplate}">
                                                <ToolTip.Triggers>
                                                    <EventTrigger RoutedEvent="Canvas.Loaded">
                                                        <BeginStoryboard>
                                                            <Storyboard>
                                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsHitTestVisible" Storyboard.TargetName="validationTooltip">
                                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                                        <DiscreteObjectKeyFrame.Value>
                                                                            <System:Boolean>true</System:Boolean>
                                                                        </DiscreteObjectKeyFrame.Value>
                                                                    </DiscreteObjectKeyFrame>
                                                                </ObjectAnimationUsingKeyFrames>
                                                            </Storyboard>
                                                        </BeginStoryboard>
                                                    </EventTrigger>
                                                </ToolTip.Triggers>
                                            </ToolTip>
                                        </ToolTipService.ToolTip>
                                        <Grid Background="Transparent" HorizontalAlignment="Right" Height="10" Margin="0,-4,-4,0" VerticalAlignment="Top" Width="10">
                                            <Path Data="M 1,0 L5,0 A 2,2 90 0 1 7,2 L7,6 z" Fill="{StaticResource ValidationBrush5}" Margin="0,3,0,0"/>
                                            <Path Data="M 0,0 L2,0 L 7,5 L7,7" Fill="{StaticResource BlankBackgroundBrush}" Margin="0,3,0,0"/>
                                        </Grid>
                                    </Border>
                                </Grid>
                            </Grid>
                            <ContentPresenter x:Name="contentPresenter" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
