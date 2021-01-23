    <TextBox Text="Test">
        <TextBox.Style>
            <Style TargetType="TextBox">
                <Setter Property="Effect">
                    <Setter.Value>
                        <DropShadowEffect ShadowDepth="0"
                                          Color="Gold"
                                          Opacity="0"
                                          BlurRadius="8"/>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsFocused" Value="True">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation To="1.0"
                                                     Storyboard.TargetProperty="(Effect).Opacity"
                                                     Duration="00:00:00"/>
                                </Storyboard>                                    
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                        <Trigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation To="0.0"
                                                     Storyboard.TargetProperty="(Effect).Opacity"
                                                     Duration="00:00:02"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.ExitActions>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </TextBox.Style>
    </TextBox>
