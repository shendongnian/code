    <Grid>
        <Grid.Triggers>
            <EventTrigger RoutedEvent="MouseDown">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard TargetName="MyLine">
                            <DoubleAnimation Storyboard.TargetProperty="X2" To="100" Duration="0:0:5"/>
                            <DoubleAnimation Storyboard.TargetProperty="Y2" To="100" Duration="0:0:5"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Grid.Triggers>
            <Line X1="10" Y1="10" X2="20" Y2="20" Stroke="Black" Name="MyLine"/>
    </Grid>
