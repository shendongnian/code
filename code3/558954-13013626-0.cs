    <Style TargetType="ListViewItem">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ListBoxItem">
                    <Border x:Name="Border" Background="Transparent" ...>
                        <VisualStateManager.VisualStateGroups>
                            ...
                            <VisualStateGroup x:Name="SelectionStates">
                                <VisualState x:Name="Unselected" />
                                <VisualState x:Name="Selected">
                                    <Storyboard>
                                        <ColorAnimationUsingKeyFrames
                                            Storyboard.TargetName="Border"
                                            Storyboard.TargetProperty="(Panel.Background).(SolidColorBrush.Color)">
                                            <EasingColorKeyFrame KeyTime="0"
                                                Value="{StaticResource SelectedBackgroundColor}" />
                                        </ColorAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                ...
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
