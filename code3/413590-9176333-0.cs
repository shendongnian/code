    <Border Width="20" Height="20" Background="Red" x:Name="border" >
                    <Border.Triggers>
                        <EventTrigger RoutedEvent="MouseEnter">
                            <BeginStoryboard Name="Ali">
                                <Storyboard>
                                    <DoubleAnimation To="0" Duration="0:0:4" Completed="com" Storyboard.TargetProperty="Opacity"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                        <EventTrigger RoutedEvent="MouseLeave">
                            <StopStoryboard  BeginStoryboardName="Ali"/>
                        </EventTrigger>
                    </Border.Triggers>
                </Border>
