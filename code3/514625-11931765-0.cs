    <Grid>
      <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="TimeHintStates">
          <VisualState x:Name="TimeHintOpenedUp">
            <Storyboard>
              <ObjectAnimationUsingKeyFrames BeginTime="00:00:00"
                                             Storyboard.TargetProperty="Visibility"
                                             Storyboard.TargetName="TimeHintVisualElement">
                <DiscreteObjectKeyFrame KeyTime="00:00:00" Value="Collapsed"/>
              </ObjectAnimationUsingKeyFrames>
            </Storyboard>
          </VisualState>
        </VisualStateGroup>
      </VisualStateManager.VisualStateGroups>
    </Grid>
