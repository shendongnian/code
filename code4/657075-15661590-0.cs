    <Style TargetType="{x:Type ListViewItem}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type ListViewItem}">
                                    <Border x:Name="Bd" Background="{TemplateBinding Background}" SnapsToDevicePixels="true">
                                        <Grid>
                                            <GridViewRowPresenter VerticalAlignment="{TemplateBinding VerticalContentAlignment}" />
                                            <ContentPresenter x:Name="contentPresenter" Visibility="Collapsed" />
                                        </Grid>
                                    </Border>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="GridView.ColumnCollection" Value="{x:Null}">
                                            <Setter TargetName="contentPresenter" Property="Visibility" Value="Visible"/>
                                        </Trigger>
                                        <Trigger Property="IsSelected" Value="true">
                                            <Trigger.EnterActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ColorAnimation Storyboard.TargetName="Bd" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)"
                                                            From="Red" To="Blue" Duration="0:0:1" />
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </Trigger.EnterActions>
                                            <Trigger.ExitActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ColorAnimation Storyboard.TargetName="Bd" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)"
                                                            From="Blue" To="Transparent" Duration="0:0:1" />
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </Trigger.ExitActions>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
