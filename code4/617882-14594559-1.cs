    <Image x:Name="image" RenderTransformOrigin="0.5,0.5" ...>
        <Image.RenderTransform>
            <RotateTransform/>
        </Image.RenderTransform>
        <Image.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard Duration="00:00:00.5" RepeatBehavior="Forever">
                        <DoubleAnimation Storyboard.TargetName="image" Storyboard.TargetProperty="(Image.RenderTransform).(RotateTransform.Angle)" By="15"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Image.Triggers>
    </Image>
