       <Grid Name="stackPanel1">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="224*" />
            </Grid.RowDefinitions>
            <TextBlock Name="statusText"
                       Grid.Row="0"
                       HorizontalAlignment="Stretch"
                       Background="Silver"
                       FontSize="20"
                       Text="{Binding Path=StatusBarText,
                                      NotifyOnTargetUpdated=True}"
                       TextAlignment="Center">
                <TextBlock.Triggers>
                    <EventTrigger RoutedEvent="Binding.TargetUpdated">
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="Opacity">
                                    <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.25" Value="1" />
                                    <EasingDoubleKeyFrame KeyTime="0:0:4" Value="1" />
                                    <EasingDoubleKeyFrame KeyTime="0:0:5" Value="0" />
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </TextBlock.Triggers>
            </TextBlock>
    </Grid>
