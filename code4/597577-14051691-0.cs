    <Style.Triggers>
        <EventTrigger RoutedEvent="FrameworkElement.Loaded">
                <BeginStoryboard Name="opacityStoryBoard">
                        <Storyboard  >
                            <DoubleAnimation Storyboard.TargetProperty="Opacity" Duration="00:00:10" From="0" To="2" />
                        </Storyboard>
                </BeginStoryboard>
        </EventTrigger>
        <EventTrigger RoutedEvent="FrameworkElement.MouseLeave">
            <SeekStoryboard BeginStoryboardName="opacityStoryBoard" Offset="00:00:00"></SeekStoryboard>
        </EventTrigger>
        <Trigger Property="FrameworkElement.Visibility" Value="Collapsed">
            <Setter Property="FrameworkElement.Opacity" Value="0"/>
        </Trigger>
    </Style.Triggers>
