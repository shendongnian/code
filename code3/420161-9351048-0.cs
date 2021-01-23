    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition />
        </Grid.RowDefinitions>
        <StackPanel>
            <Button Content="Move it">
                <Button.Triggers>
                    <EventTrigger RoutedEvent="Button.Click" >
                        <BeginStoryboard>
                            <Storyboard Storyboard.TargetName="theEllipse" Duration="00:00:05">
                                <DoubleAnimation From="-5" To="145" Storyboard.TargetProperty="(Canvas.Left)"/>
                                <DoubleAnimation From="-5" To="35" Storyboard.TargetProperty="(Canvas.Top)"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Button.Triggers>
            </Button>
        </StackPanel>
        <Border Margin="10" Grid.Row="1">
            <Canvas>
                <Ellipse x:Name="theEllipse" Width="10" Height="10" Fill="BlueViolet" Canvas.Left="-5" Canvas.Top="-5" />
            </Canvas>
        </Border>
    </Grid>
