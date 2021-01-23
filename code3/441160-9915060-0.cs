    <Style TargetType="Button">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Grid>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="Normal"/>
                                <VisualState x:Name="Disabled"/>
                                <VisualState x:Name="MouseOver">
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetName="mouseOverBackgroundImage" Storyboard.TargetProperty="Opacity" Duration="0:0:0.1" To="1"/>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Pressed">
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetName="pressedBackgroundImage" Storyboard.TargetProperty="Opacity" Duration="0:0:0.1" To="1"/>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Image Name="normalBackgroundImage" Source="{TemplateBinding local:BackgroundImages.NormalBackgroundImage}"/>
                        <Image Name="mouseOverBackgroundImage" Source="{TemplateBinding local:BackgroundImages.MouseOverBackgroundImage}" Opacity="0"/>
                        <Image Name="pressedBackgroundImage" Source="{TemplateBinding local:BackgroundImages.PressedBackgroundImage}" Opacity="0"/>
                        <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
