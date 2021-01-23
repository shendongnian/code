     <Application.Resources>
            <Style TargetType="{x:Type Image}">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="MouseEnter">
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Width)">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="335">
                                        <EasingDoubleKeyFrame.EasingFunction>
                                            <BackEase EasingMode="EaseOut"/>
                                        </EasingDoubleKeyFrame.EasingFunction>
                                    </EasingDoubleKeyFrame>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </Application.Resources>
