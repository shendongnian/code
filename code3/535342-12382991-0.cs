     <Storyboard x:Name="FromMainToBack">
      <DoubleAnimationUsingKeyFrames Storyboard.TargetName="ScaleContainerGrid" Storyboard.TargetProperty="ScaleY">
        <LinearDoubleKeyFrame KeyTime="0:0:0.2" Value="0.8"/>
        <LinearDoubleKeyFrame KeyTime="0:0:1.2" Value="0.8"/>
        <LinearDoubleKeyFrame KeyTime="0:0:1.5" Value="1"/>
      </DoubleAnimationUsingKeyFrames>
      <DoubleAnimationUsingKeyFrames Storyboard.TargetName="ScaleContainerGrid" Storyboard.TargetProperty="ScaleX">
        <LinearDoubleKeyFrame KeyTime="0:0:0.2" Value="0.8"/>
        <LinearDoubleKeyFrame KeyTime="0:0:1.2" Value="0.8"/>
        <LinearDoubleKeyFrame KeyTime="0:0:1.5" Value="1"/>
      </DoubleAnimationUsingKeyFrames>
      <DoubleAnimation BeginTime="0:0:0.2" Duration="0:0:0.5" From="0" To="90" Storyboard.TargetName="planeProjectionMain" Storyboard.TargetProperty="RotationY">
        <DoubleAnimation.EasingFunction>
          <BackEase EasingMode="EaseIn"/>
        </DoubleAnimation.EasingFunction>
      </DoubleAnimation>
      <DoubleAnimation BeginTime="0:0:0.7" Duration="0:0:0.5" From="270" To="360" Storyboard.TargetName="planeProjectionBack" Storyboard.TargetProperty="RotationY">
        <DoubleAnimation.EasingFunction>
          <BackEase Amplitude="0" EasingMode="EaseOut"/>
        </DoubleAnimation.EasingFunction>
      </DoubleAnimation>
    </Storyboard>
