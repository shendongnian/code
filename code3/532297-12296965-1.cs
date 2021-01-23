    <ControlTemplate TargetType="Button">
        <Grid x:Name="RootElement" Background="Transparent">
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="MouseOver">
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetName="buttonScale" Storyboard.TargetProperty="ScaleX" To="1.2" Duration="00:00:00.25"/>
                            <DoubleAnimation Storyboard.TargetName="buttonScale" Storyboard.TargetProperty="ScaleY" To="1.2" Duration="00:00:00.25" />
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="Pressed">
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetName="buttonScale" Storyboard.TargetProperty="ScaleX" To="1.4" Duration="00:00:00.25" />
                            <DoubleAnimation Storyboard.TargetName="buttonScale" Storyboard.TargetProperty="ScaleY" To="1.4" Duration="00:00:00.25" />
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="Normal"/>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            <ContentPresenter Content="{TemplateBinding Content}" RenderTransformOrigin="0.5,0.5">
                <ContentPresenter.RenderTransform>
                    <ScaleTransform x:Name="buttonScale" />
                </ContentPresenter.RenderTransform>
            </ContentPresenter>
        </Grid>
    </ControlTemplate>
