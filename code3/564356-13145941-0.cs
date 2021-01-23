    <Control>
                <Control.Template>
                    <ControlTemplate>
                        <DockPanel>
                            <ToggleButton x:Name="btn" Content="IsBold"/>
                            <Grid Width="200">
                                <TextBlock Text="Transition" x:Name="normal" TextAlignment="Center"/>
                                <TextBlock Text="Transition" FontWeight="Bold" Opacity="0" x:Name="bold" TextAlignment="Center"/>
                            </Grid>
                        </DockPanel>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" SourceName="btn" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard Duration="00:00:01">
                                            <DoubleAnimation Storyboard.TargetName="normal" Storyboard.TargetProperty="Opacity" To="0"/>
                                            <DoubleAnimation Storyboard.TargetName="bold" Storyboard.TargetProperty="Opacity" To="1"/>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard Duration="00:00:01">
                                            <DoubleAnimation Storyboard.TargetName="normal" Storyboard.TargetProperty="Opacity" To="1"/>
                                            <DoubleAnimation Storyboard.TargetName="bold" Storyboard.TargetProperty="Opacity" To="0"/>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                        
                        
                        
                    </ControlTemplate>
                </Control.Template>
            </Control>
