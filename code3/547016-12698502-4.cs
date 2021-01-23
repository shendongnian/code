    <Style TargetType="ToggleButton" x:Key="FlipButton">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ToggleButton">
                    <Grid>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CheckStates">
                                <VisualState x:Name="Checked">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" Storyboard.TargetName="rotate" Storyboard.TargetProperty="(RotateTransform.Angle)" To="180" />
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Unchecked">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" Storyboard.TargetName="rotate" Storyboard.TargetProperty="(RotateTransform.Angle)" To="0" />
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <ContentPresenter Content="{TemplateBinding Content}">
                            <ContentPresenter.RenderTransform>
                                <RotateTransform x:Name="rotate" CenterX="0.5" CenterY="0.5" />
                            </ContentPresenter.RenderTransform>
                        </ContentPresenter>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
