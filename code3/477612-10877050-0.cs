    <Grid Name="WindowGrid">
        <Grid.Triggers>
            <EventTrigger RoutedEvent="MouseEnter">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation 
                            Storyboard.TargetName="ControlsGrid" 
                            Storyboard.TargetProperty="(Grid.Height)"
                            From="0" 
                            To="66" 
                            Duration="0:0:0.5" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="MouseLeave">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation 
                            Storyboard.TargetName="ControlsGrid"
                            Storyboard.TargetProperty="(Grid.Height)"
                            From="66" 
                            To="0" 
                            Duration="0:0:0.5" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Grid.Triggers>
        <!-- 
            This is a sample content to demostrate animation;
            Without it 'WindowGrid' will be collapsed.
        -->
        <ListBox />
        
        <Grid Margin="0" Name="ControlsGrid" VerticalAlignment="Bottom" Background="#B4000000" />
    </Grid>
