                            <Storyboard x:Name="HideChangePasswordPanel">
                                <DoubleAnimation EnableDependentAnimation="True" Storyboard.TargetName="ChangePasswordPanel" Storyboard.TargetProperty="Height" From="190" To="0" Duration="0:0:0.2">
                                    <DoubleAnimation.EasingFunction>
                                        <PowerEase EasingMode="EaseIn"></PowerEase>
                                    </DoubleAnimation.EasingFunction>
                                </DoubleAnimation>
                            </Storyboard>
                            <Storyboard x:Name="ShowChangePasswordPanel">
                                <DoubleAnimation EnableDependentAnimation="True" Storyboard.TargetName="ChangePasswordPanel" Storyboard.TargetProperty="Height" From="0" To="190" Duration="0:0:0.2">
                                    <DoubleAnimation.EasingFunction>
                                        <PowerEase EasingMode="EaseIn"></PowerEase>
                                    </DoubleAnimation.EasingFunction>
                                </DoubleAnimation>
                            </Storyboard>
