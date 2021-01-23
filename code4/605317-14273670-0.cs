    <Storyboard
                                    x:Name="myStoryboard2">
                                    <DoubleAnimation
                                        x:Name="minuteAnimation"
                                        Storyboard.TargetName="minHandTransform"
                                        Storyboard.TargetProperty="Angle"
                                        Duration="0:0:59"
                                        From="{Binding Time, Converter={StaticResource minuteHandTransform}}"
                                        To="{Binding Time, Converter={StaticResource minuteHandTransform}}"
                                        RepeatBehavior="Forever">
                                        <DoubleAnimation.EasingFunction>
                                            <SineEase
                                                EasingMode="EaseOut" />
                                        </DoubleAnimation.EasingFunction>
                                    </DoubleAnimation>
                                </Storyboard>
