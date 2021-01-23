        <Grid.Triggers>
    <EventTrigger RoutedEvent="ToggleButton.Checked" SourceName="workingPlanButton">
    <BeginStoryboard>
    <Storyboard Completed="Storyboard_Completed">
    <BooleanAnimationUsingKeyFrames Storyboard.Target="{Binding ElementName=blockViewControl}"
                                   Storyboard.TargetProperty="IsStudyplanAnimationNotPlaying"
                                   Timeline.DesiredFrameRate="30">
    <DiscreteBooleanKeyFrame KeyTime="0:0:0.0" Value="False" />
    </BooleanAnimationUsingKeyFrames>
    
    <DoubleAnimationUsingKeyFrames BeginTime="00:00:0.1"
                                  Duration="0:0:00.5"
                                  Storyboard.TargetName="lsView"
                                  Storyboard.TargetProperty="RenderTransform.(TranslateTransform.Y)"
                                  Timeline.DesiredFrameRate="30">
    <LinearDoubleKeyFrame KeyTime="00:00:00.3" Value="{Binding ElementName=bodyGrid, Path=ActualHeight}" />
    </DoubleAnimationUsingKeyFrames>
    
    <BooleanAnimationUsingKeyFrames BeginTime="0:0:00.3"
                                   Storyboard.Target="{Binding ElementName=blockViewControl}"
                                   Storyboard.TargetProperty="IsStudyplanAnimationNotPlaying"
                                   Timeline.DesiredFrameRate="30">
    <DiscreteBooleanKeyFrame KeyTime="0:0:0.0" Value="True" />
    </BooleanAnimationUsingKeyFrames>
    
     
    <!--  Hide the panel  -->
    <ObjectAnimationUsingKeyFrames BeginTime="0:0:0.5"
                                  Storyboard.TargetName="lsView"
                                  Storyboard.TargetProperty="Visibility"
                                  Timeline.DesiredFrameRate="30">
    <DiscreteObjectKeyFrame Value="{x:Static Visibility.Hidden}" />
    </ObjectAnimationUsingKeyFrames>
    </Storyboard>
    </BeginStoryboard>
    </EventTrigger>
     
