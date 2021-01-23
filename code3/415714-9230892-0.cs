    <Style TargetType="Button" x:Key="DefaultButtonStyle">
            <Setter Property="Background" Value="{StaticResource NormalBrush}"/>
            <Setter Property="Foreground" Value="{StaticResource TextContentBrush}"/>
            <Setter Property="FontFamily" Value="{StaticResource ContentFontFamily}"/>
            <Setter Property="FontSize" Value="{StaticResource ContentFontSize}"/>
    		<Setter Property="HorizontalContentAlignment" Value="Center"/>
    		<Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="Padding" Value="3"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="BorderBrush" Value="{StaticResource NormalBorderBrush}"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
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
                                        <VisualTransition From="MouseOver" GeneratedDuration="0:0:0.1" To="Pressed">
                                            <VisualTransition.GeneratedEasingFunction>
                                                <ExponentialEase EasingMode="EaseIn" Exponent="-2"/>
                                            </VisualTransition.GeneratedEasingFunction>
                                        </VisualTransition>
                                        <VisualTransition From="Pressed" GeneratedDuration="0:0:0.1" To="MouseOver">
                                            <VisualTransition.GeneratedEasingFunction>
                                                <ExponentialEase EasingMode="EaseOut" Exponent="0"/>
                                            </VisualTransition.GeneratedEasingFunction>
                                        </VisualTransition>
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
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="MouseOverBorder">
                                                <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Control.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="contentPresenter">
                                                <EasingColorKeyFrame KeyTime="0" Value="{StaticResource BaseColor2}"/>
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Pressed">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="PressedBorder" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="1.0" KeySpline="0,0,0.0299999993294477,0.920000016689301"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)" Storyboard.TargetName="grid">
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.01" Value="1.05"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" Storyboard.TargetName="grid">
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.01" Value="1.05"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Control.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="contentPresenter">
                                                <EasingColorKeyFrame KeyTime="0" Value="{StaticResource BaseColor2}"/>
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="DisabledVisualElement" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="0.75"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="contentPresenter" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="0.3"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="FocusStates">
                                    <VisualState x:Name="Focused">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="FocusVisualElement" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="1.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Unfocused"/>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Border x:Name="BaseBorder" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="1" CornerRadius="1" >
                                <Border.Background>
                                    <SolidColorBrush Color="{StaticResource BaseColor7}"/>
                                </Border.Background>
                                <Grid>
                                    <Border x:Name="Background" BorderBrush="{StaticResource NormalInnerBorderBrush}" Background="{TemplateBinding Background}"/>
                                    <Border x:Name="MouseOverBorder" Opacity="0" Background="{StaticResource MouseOverBrush}" Margin="-0.5,-0.5,0.5,0.5"/>
    
                                    <Border x:Name="PressedBorder" BorderThickness="{TemplateBinding BorderThickness}" Opacity="0" Background="{StaticResource MouseOverBrush}" RenderTransformOrigin="0.5,0.5" Margin="-1">
                                        <Border.RenderTransform>
                                            <TransformGroup>
                                                <ScaleTransform/>
                                                <SkewTransform/>
                                                <RotateTransform/>
                                                <TranslateTransform/>
                                            </TransformGroup>
                                        </Border.RenderTransform>
                                    </Border>
                                </Grid>
                            </Border>
                            <Rectangle x:Name="DisabledVisualElement" Fill="{StaticResource DisabledBackgroundBrush}" IsHitTestVisible="false" Opacity="0" RadiusY="1" RadiusX="1" Stroke="{StaticResource DisabledBackgroundBrush}"/>
                            <ContentControl x:Name="contentPresenter" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}" Foreground="{TemplateBinding Foreground}" />
                            <Rectangle x:Name="FocusVisualElement" IsHitTestVisible="false" Stroke="{StaticResource FocusedBrush}" Margin="-1" Opacity="0"/>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
