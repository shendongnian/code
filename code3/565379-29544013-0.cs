    <Style x:Key="OnOffSwitchToggleButton" TargetType="{x:Type ToggleButton}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ToggleButton}">
                            <Grid Margin="0,0,0,-0.033">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="0.456*"/>
                                    <ColumnDefinition Width="0.544*"/>
                                </Grid.ColumnDefinitions>
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal">
                                            <Storyboard>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)" Storyboard.TargetName="Switch">
                                                    <EasingDoubleKeyFrame KeyTime="0" Value="0.083"/>
                                                </DoubleAnimationUsingKeyFrames>
                                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)" Storyboard.TargetName="path1">
                                                    <EasingColorKeyFrame KeyTime="0" Value="White"/>
                                                </ColorAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="MouseOver">
                                            <Storyboard>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Effect).(DropShadowEffect.Opacity)" Storyboard.TargetName="path">
                                                    <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
                                                </DoubleAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Pressed"/>
                                        <VisualState x:Name="Disabled"/>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="CheckStates">
                                        <VisualState x:Name="Checked">
                                            <Storyboard>
                                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)" Storyboard.TargetName="path">
                                                    <EasingColorKeyFrame KeyTime="0:0:0.2" Value="#FF39B54A"/>
                                                </ColorAnimationUsingKeyFrames>
                                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Stroke).(SolidColorBrush.Color)" Storyboard.TargetName="path">
                                                    <EasingColorKeyFrame KeyTime="0:0:0.2" Value="#FF319D40"/>
                                                </ColorAnimationUsingKeyFrames>
                                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(TextElement.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="label">
                                                    <EasingColorKeyFrame KeyTime="0" Value="#00999999"/>
                                                    <DiscreteColorKeyFrame KeyTime="0:0:0.2" Value="#0039B54A"/>
                                                    <EasingColorKeyFrame KeyTime="0:0:0.3" Value="White"/>
                                                </ColorAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(ContentControl.Content)" Storyboard.TargetName="label">
                                                    <DiscreteObjectKeyFrame KeyTime="0:0:0.2" Value="ON"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.HorizontalAlignment)" Storyboard.TargetName="Switch">
                                                    <DiscreteObjectKeyFrame KeyTime="0:0:0.2" Value="{x:Static HorizontalAlignment.Left}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="Switch">
                                                    <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="39.965"/>
                                                </DoubleAnimationUsingKeyFrames>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="label">
                                                    <DiscreteDoubleKeyFrame KeyTime="0:0:0.2" Value="-19.224"/>
                                                </DoubleAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Unchecked">
                                            <Storyboard>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="Switch">
                                                    <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="0"/>
                                                </DoubleAnimationUsingKeyFrames>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="label">
                                                    <EasingDoubleKeyFrame KeyTime="0" Value="0"/>
                                                    <DiscreteDoubleKeyFrame KeyTime="0:0:0.2" Value="0"/>
                                                </DoubleAnimationUsingKeyFrames>
                                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(TextElement.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="label">
                                                    <EasingColorKeyFrame KeyTime="0" Value="#00999999"/>
                                                    <EasingColorKeyFrame KeyTime="0:0:0.2" Value="#00999999"/>
                                                    <EasingColorKeyFrame KeyTime="0:0:0.3" Value="#FF999999"/>
                                                </ColorAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Indeterminate"/>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Canvas RenderTransformOrigin="0.5,0.5" x:Name="_switch" UseLayoutRounding="False" Height="30" Width="70"  Grid.ColumnSpan="2">
    <Canvas.RenderTransform>
                                            <TransformGroup>
                                                <ScaleTransform/>
                                                <SkewTransform/>
                                                <RotateTransform/>
                                                <TranslateTransform/>
                                            </TransformGroup>
                                        </Canvas.RenderTransform>
    
                                    <Canvas x:Name="Background" Height="30" Canvas.Left="0" Canvas.Top="0" Width="70" RenderTransformOrigin="0.5,0.5">
                                        <Canvas.RenderTransform>
                                            <TransformGroup>
                                                <ScaleTransform/>
                                                <SkewTransform/>
                                                <RotateTransform/>
                                                <TranslateTransform/>
                                            </TransformGroup>
                                        </Canvas.RenderTransform>
                                        <Path x:Name="path" Height="30" Canvas.Left="0" Canvas.Top="0" Width="70" Data="F1M55.0161,-0.966799999999999L14.9831,-0.966799999999999C6.7081,-0.966799999999999,0.00010000000000332,5.7412,0.00010000000000332,14.0162C0.00010000000000332,22.2922,6.7081,29.0002,14.9831,29.0002L55.0161,29.0002C63.2911,29.0002,70.0001,22.2922,70.0001,14.0162C70.0001,5.7412,63.2911,-0.966799999999999,55.0161,-0.966799999999999" Fill="#FFEDEDED" Stretch="Fill" Stroke="#FFCCCCCC">
                                            <Path.Effect>
                                                <DropShadowEffect ShadowDepth="0" Color="#FF00ADEF" Opacity="0"/>
                                            </Path.Effect>
                                        </Path>
                                    </Canvas>
                                    <Grid x:Name="Switch" Height="22" Canvas.Left="4.815" Canvas.Top="3.568" Width="22" RenderTransformOrigin="0.5,0.5">
                                        <Grid.RenderTransform>
                                            <TransformGroup>
                                                <ScaleTransform/>
                                                <SkewTransform/>
                                                <RotateTransform/>
                                                <TranslateTransform/>
                                            </TransformGroup>
                                        </Grid.RenderTransform>
                                        <Grid.Effect>
                                            <DropShadowEffect BlurRadius="3" ShadowDepth="0" Opacity="0.5"/>
                                        </Grid.Effect>
                                        <Path x:Name="path1" Data="F1M14.9614,27.0166C7.7934,27.0166,1.9614,21.1846,1.9614,14.0166C1.9614,6.8486,7.7934,1.0166,14.9614,1.0166C22.1294,1.0166,27.9614,6.8486,27.9614,14.0166C27.9614,21.1846,22.1294,27.0166,14.9614,27.0166" Height="22" Stretch="Fill" Width="22" Margin="0" Fill="White"/>
                                    </Grid>
                                </Canvas>
                                <Label x:Name="label" Content="OFF" Grid.Column="1" Margin="-2.506,2,0,0" HorizontalAlignment="Left" Padding="0" VerticalAlignment="Center" FontFamily="Avenir 45" FontSize="14.667" Foreground="#FF999999" RenderTransformOrigin="0.5,0.5">
                                    <Label.RenderTransform>
                                        <TransformGroup>
                                            <ScaleTransform/>
                                            <SkewTransform/>
                                            <RotateTransform/>
                                            <TranslateTransform/>
                                        </TransformGroup>
                                    </Label.RenderTransform>
                                </Label>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Setter Property="HorizontalAlignment" Value="Left"/>
            </Style>
