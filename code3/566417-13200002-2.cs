    <Grid>
        <Grid.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetName="Line1" Storyboard.TargetProperty="X2" To="100" Duration="0:0:5"/>
                            <DoubleAnimation Storyboard.TargetName="Line1" Storyboard.TargetProperty="Y2" To="100" Duration="0:0:5"/>
                            <DoubleAnimation Storyboard.TargetName="Line2" Storyboard.TargetProperty="X2" To="200" Duration="0:0:5" BeginTime="0:0:5"/>
                            <DoubleAnimation Storyboard.TargetName="Line2" Storyboard.TargetProperty="Y2" To="0" Duration="0:0:5" BeginTime="0:0:5"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Grid.Triggers>
            <Line X1="10" Y1="10" X2="10" Y2="10" Stroke="Black" Name="Line1"/>
        <Line X1="100" Y1="100" X2="100" Y2="100" Stroke="Black" Name="Line2"/>
    </Grid>
