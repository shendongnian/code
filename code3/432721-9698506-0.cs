    <Style TargetType="Image">
        <Setter Property="Margin" Value="0,1,10,1"/>
        <Setter Property="DockPanel.Dock" Value="Right"/>
        <Setter Property="RenderTransformOrigin" Value="0.5,0.5"/>
        <Setter Property="RenderTransform">
            <Setter.Value>
                <ScaleTransform ScaleX="1" ScaleY="1" />
            </Setter.Value>
        </Setter>
        <Setter Property="Effect">
            <Setter.Value>
                <DropShadowEffect BlurRadius="20" ShadowDepth="0" Color="White"/>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <EventTrigger RoutedEvent="Image.MouseEnter">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <ColorAnimation
                                Storyboard.TargetProperty="Effect.Color"
                                From="White"
                                To="Red"
                                Duration="0:0:1">
                            </ColorAnimation>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
                
            <EventTrigger RoutedEvent="Image.MouseLeave">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <ColorAnimation
                                Storyboard.TargetProperty="Effect.Color"
                                From="Red"
                                To="White"
                                Duration="0:0:1">
                            </ColorAnimation>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
            <EventTrigger RoutedEvent="Image.MouseLeftButtonDown">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation
                                Storyboard.TargetProperty="RenderTransform.ScaleX"
                                From="1"
                                To=".9"
                                Duration="0:0:0.1">
                            </DoubleAnimation>
                            <DoubleAnimation
                                Storyboard.TargetProperty="RenderTransform.ScaleY"
                                From="1"
                                To=".9"
                                Duration="0:0:0.1">
                            </DoubleAnimation>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
            <EventTrigger RoutedEvent="Image.MouseLeftButtonUp">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation
                                Storyboard.TargetProperty="RenderTransform.ScaleX"
                                From=".9"
                                To="1"
                                Duration="0:0:0.1">
                            </DoubleAnimation>
                            <DoubleAnimation
                                Storyboard.TargetProperty="RenderTransform.ScaleY"
                                From=".9"
                                To="1"
                                Duration="0:0:0.1">
                            </DoubleAnimation>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Style.Triggers>
    </Style>
