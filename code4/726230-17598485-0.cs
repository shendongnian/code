    <Canvas Name=" Canvas1" Visibility="Visible">
    <Canvas.Style>
        <Style TargetType="Canvas">
            <Style.Triggers>
                <Trigger Property="Visibility" Value="Visible">
                    <Setter Property="DataContext" Value="{Binding}"/>
                </Trigger>
                <Trigger Property="Visibility" Value="Hidden">
                    <Setter Property="DataContext" Value="{x:Null}"/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Canvas.Style>
    <k:KinectRegion KinectSensor="{Binding kinectSensor}" Name="kinectRegionCP">
        // some controls
