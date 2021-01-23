    <Trigger Property="Popup.IsOpen" Value="True">
       <Trigger.EnterActions>
          <BeginStoryboard Name="OpenStoryboard">
              <Storyboard>
                  <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(ScaleTransform.ScaleY)">
                      <SplineDoubleKeyFrame KeyTime="0:0:0" Value="0" />
                      <SplineDoubleKeyFrame KeyTime="0:0:0.5" Value="1" />
                  </DoubleAnimationUsingKeyFrames>
                  <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)">
                      <SplineDoubleKeyFrame KeyTime="0:0:0" Value="0" />
                      <SplineDoubleKeyFrame KeyTime="0:0:0.5" Value="1" />
                      <SplineDoubleKeyFrame KeyTime="0:0:2" Value="1" />
                      <SplineDoubleKeyFrame KeyTime="0:0:4" Value="0" />
                  </DoubleAnimationUsingKeyFrames>
                  <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen">
                      <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="True" />
                      <DiscreteBooleanKeyFrame KeyTime="0:0:4" Value="False" />
                  </BooleanAnimationUsingKeyFrames>
              </Storyboard>
          </BeginStoryboard>
       </Trigger.EnterActions>
       <Trigger.ExitActions>
          <StopStoryboard BeginStoryboardName="OpenStoryboard"/>
       </Trigger.ExitActions>
    </Trigger>
