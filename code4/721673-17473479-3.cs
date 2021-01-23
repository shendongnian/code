    <Style.Triggers>
        <Trigger Property="IsMouseOver" Value="True">
            <Trigger.EnterActions>
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Height" From="20" To="85"
                                         Duration="0:0:0.5" FillBehavior="Stop" />
                    </Storyboard>
                </BeginStoryboard>
            </Trigger.EnterActions>
            <Setter Property="Height" Value="85" />
            <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto" />
        </Trigger>
    </Style.Triggers>
