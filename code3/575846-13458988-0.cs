    <ControlTemplate x:Key="RadioButtonTemplate" TargetType="{x:Type RadioButton}">
                        <ControlTemplate.Resources>
                            <Storyboard x:Key="CheckedFalse">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="CheckIcon" Storyboard.TargetProperty="(UIElement.Opacity)">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.3000000" Value="0"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="CheckedTrue">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="CheckIcon" Storyboard.TargetProperty="(UIElement.Opacity)">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.1000000" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="HoverOn">
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="BackgroundOverlay" Storyboard.TargetProperty="(UIElement.Opacity)">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.2000000" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="HoverOff">
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="BackgroundOverlay" Storyboard.TargetProperty="(UIElement.Opacity)">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.3000000" Value="0"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="PressedOn">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Background" Storyboard.TargetProperty="(UIElement.Opacity)">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.2000000" Value="0.6"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="PressedOff">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Background" Storyboard.TargetProperty="(UIElement.Opacity)">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.2000000" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                        </ControlTemplate.Resources>
                        <BulletDecorator Background="Transparent">
                            <BulletDecorator.Bullet>
                                <Grid Width="16" Height="16">
                                    <Ellipse Height="14"
                           Margin="1"
                           x:Name="Background"
                           Width="14"
                           Fill="{StaticResource NormalBrush}"
                           Stroke="{TemplateBinding BorderBrush}"
                           StrokeThickness="2"/>
                                    <Ellipse Height="12"
                           x:Name="BackgroundOverlay"
                           Width="12"
                           Opacity="0"
                           Fill="{StaticResource HoverBrush}"
                           Stroke="#00000000"
                           Margin="2,2,2,2"
                           StrokeThickness="0"/>
                                    <Border HorizontalAlignment="Center"
                          VerticalAlignment="Center"
                          Width="6"
                          Height="6"
                          CornerRadius="1,1,1,1"
                          BorderThickness="1,1,1,1"
                          Background="#FFFFFFFF"
                          x:Name="CheckIcon"
                          BorderBrush="{StaticResource CheckIconBrush}"
                          Opacity="0"/>
                                </Grid>
                            </BulletDecorator.Bullet>
                            <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}" RecognizesAccessKey="True"/>
                        </BulletDecorator>
    
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource CheckedFalse}" x:Name="CheckedFalse_BeginStoryboard"/>
                                </Trigger.ExitActions>
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource CheckedTrue}"/>
                                </Trigger.EnterActions>
                            </Trigger>
                            <Trigger Property="IsChecked" Value="False">
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource CheckedTrue}" x:Name="CheckedTrue_BeginStoryboard"/>
                                </Trigger.ExitActions>
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource CheckedFalse}"/>
                                </Trigger.EnterActions>
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="true">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource HoverOn}"/>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource HoverOff}"/>
                                </Trigger.ExitActions>
                            </Trigger>
                            <Trigger Property="IsPressed" Value="true">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource PressedOn}"/>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource PressedOff}"/>
                                </Trigger.ExitActions>
                            </Trigger>
                            <Trigger Property="IsEnabled" Value="false">
                                <Setter Property="Fill" TargetName="Background" Value="{DynamicResource DisabledBackgroundBrush}"/>
                                <Setter Property="Stroke" TargetName="Background" Value="{DynamicResource DisabledBorderBrush}"/>
                            </Trigger>
    
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
