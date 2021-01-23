    <StackPanel>
        <Button x:Name="button"
                Content="Button" />
        <Button x:Name="button2"
                Content="Button 2" />
        <Popup Placement="Right"
               PlacementTarget="{Binding ElementName=button}">
            <Menu>
                <MenuItem Header="AAA" />
            </Menu>
            <Popup.Style>
                <Style TargetType="{x:Type Popup}">
                    <Setter Property="IsOpen"
                            Value="True" />
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self},
                                                             Path=PlacementTarget.IsMouseOver}"
                                           Value="False" />
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self},
                                                             Path=IsMouseOver}"
                                           Value="False" />
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.EnterActions>
                                <BeginStoryboard x:Name="HidePopupStoryboard">
                                    <Storyboard>
                                        <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen"
                                                                        Duration="0:0:0.1">
                                            <DiscreteBooleanKeyFrame KeyTime="100%"
                                                                     Value="False" />
                                        </BooleanAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </MultiDataTrigger.EnterActions>
                            <MultiDataTrigger.ExitActions>
                                <StopStoryboard BeginStoryboardName="HidePopupStoryboard" />
                            </MultiDataTrigger.ExitActions>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </Popup.Style>
        </Popup>
    </StackPanel>
