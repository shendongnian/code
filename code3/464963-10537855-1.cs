    <Style TargetType="Button">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Grid RenderTransformOrigin="0.5, 0.5">
                        <Grid.RenderTransform>
                            <ScaleTransform x:Name="scale" ScaleX="0.5"/>
                        </Grid.RenderTransform>
                        <Ellipse Height="50" Width="150" Fill="Transparent" StrokeThickness="1" Stroke="Black" />
                        <TextBlock Width="150" HorizontalAlignment="Center" VerticalAlignment="Center"
                                   TextAlignment="Center" TextWrapping="Wrap" Text="{TemplateBinding Content}"/>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Trigger.EnterActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation
                                            Storyboard.TargetName="scale"
                                            Storyboard.TargetProperty="ScaleX"
                                            To="1.2" Duration="0:0:0.3"/>
                                        <DoubleAnimation Storyboard.TargetName="scale"
                                            Storyboard.TargetProperty="ScaleY"
                                            To="1.2" Duration="0:0:0.3"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </Trigger.EnterActions>
                            <Trigger.ExitActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation
                                            Storyboard.TargetName="scale"
                                            Storyboard.TargetProperty="ScaleX"
                                            From="1.2" Duration="0:0:0.2"/>
                                        <DoubleAnimation
                                            Storyboard.TargetName="scale"
                                            Storyboard.TargetProperty="ScaleY"
                                            From="1.2" Duration="0:0:0.2"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </Trigger.ExitActions>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
