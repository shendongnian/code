        <Button Name="CloseThisPopUp" VerticalAlignment="Top" HorizontalAlignment="Right" Content="X">
                                            <Button.Triggers>
                                                <EventTrigger RoutedEvent="Button.Click">
                                                    <EventTrigger.Actions>
                                                        <BeginStoryboard>
                                                            <Storyboard>
                                                                <BooleanAnimationUsingKeyFrames Storyboard.TargetName="CloseThisPopUp" Storyboard.TargetProperty="IsOpen">
                                                                    <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="False" />
                                                                </BooleanAnimationUsingKeyFrames>
                                                            </Storyboard>
                                                        </BeginStoryboard>
                                                    </EventTrigger.Actions>
                                                </EventTrigger>
                                            </Button.Triggers>
                                        </Button>
