    <Window.Triggers>
        <EventTrigger RoutedEvent="Window.MouseDown" >
            <EventTrigger.Actions>
                <BeginStoryboard>
                    <Storyboard TargetProperty="Left">
                        <DoubleAnimation From="500" To="515" Duration="0:0:0.05"
                                         AutoReverse="True" RepeatBehavior="3x"
                                         FillBehavior="Stop"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger.Actions>
        </EventTrigger>
    </Window.Triggers>
