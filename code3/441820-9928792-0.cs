    <Style x:Key="test" TargetType="{x:Type Image}">
        <Style.Resources>
            <Storyboard x:Key="Storyboard1">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Width)" 
                    **Storyboard.Target="{Binding RelativeSource={RelativeSource Self}}"**>
                    <EasingDoubleKeyFrame KeyTime="0:0:1" Value="200">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <BackEase EasingMode="EaseOut"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Style.Resources>
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Trigger.EnterActions>
                    <BeginStoryboard Storyboard="{StaticResource Storyboard1}"/>
                </Trigger.EnterActions>
            </Trigger>
        </Style.Triggers>
