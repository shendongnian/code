                      <Trigger Property="IsMouseOver" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Name="fred">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <LinearGradientBrush EndPoint="0,1" StartPoint="0,0" Opacity="0.5">
                                                            <GradientStop Color="#FFCFF9C4" Offset="0"/>
                                                            <GradientStop Color="#FF249505" Offset="1"/>
                                                            <GradientStop Color="#FF58D835" Offset="0.5"/>
                                                        </LinearGradientBrush>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <RemoveStoryboard BeginStoryboardName="fred" />
                                </Trigger.ExitActions>
                            </Trigger>
