             <!-- **********
                Ok, so we know this is the bugger we want to deal with.
                -->
                <Style TargetType="CalendarButton"
                       x:Key="CalendarButtonStyle">
                  <Setter Property="MinWidth"
                          Value="40" />
                  <Setter Property="MinHeight"
                          Value="42" />
                  <Setter Property="FontSize"
                          Value="10" />
                  <Setter Property="HorizontalContentAlignment"
                          Value="Center" />
                  <Setter Property="VerticalContentAlignment"
                          Value="Center" />
                  <Setter Property="Template">
                    <Setter.Value>
                      <ControlTemplate TargetType="CalendarButton">
                        <Grid>
                <!-- *************
                What we want to change is the stuff that happens
            for an State, in this case the Selected State. So we just
            go look at what exactly it is doing for that Selected State.
                -->
                          <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup Name="CommonStates">
                              <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0:0:0.1" />
                              </VisualStateGroup.Transitions>
                              <VisualState Name="Normal" />
                              <VisualState Name="MouseOver">
                                <Storyboard>
                                  <DoubleAnimation Storyboard.TargetName="Background"
                                                   Storyboard.TargetProperty="Opacity"
                                                   To=".5"
                                                   Duration="0" />
                                </Storyboard>
                              </VisualState>
                              <VisualState Name="Pressed">
                                <Storyboard>
                                  <DoubleAnimation Storyboard.TargetName="Background"
                                                   Storyboard.TargetProperty="Opacity"
                                                   To=".5"
                                                   Duration="0" />
                                </Storyboard>
                              </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup Name="SelectionStates">
                              <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0" />
                              </VisualStateGroup.Transitions>
                              <VisualState Name="Unselected" />
                <!-- ************
            Hey, look at that. So this guy's telling something called "SelectedBackground" 
            with some opacity to show up and be seen. Now we know we need to go check out 
            this SelectedBackground object he's talking to.
                -->
                              <VisualState Name="Selected">
                                <Storyboard>
                                  <DoubleAnimation Storyboard.TargetName="SelectedBackground"
                                                   Storyboard.TargetProperty="Opacity"
                                                   To=".75"
                                                   Duration="0" />
                                </Storyboard>
                              </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup Name="ActiveStates">
                              <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0" />
                              </VisualStateGroup.Transitions>
                              <VisualState Name="Active" />
                              <VisualState Name="Inactive">
                                <Storyboard>
                                  <ColorAnimation Duration="0"
                                                  Storyboard.TargetName="NormalText"
                                                  Storyboard.TargetProperty="(TextElement.Foreground).
                                      (SolidColorBrush.Color)"
                                                  To="#FF777777" />
                                </Storyboard>
                              </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup Name="CalendarButtonFocusStates">
                              <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0" />
                              </VisualStateGroup.Transitions>
                              <VisualState Name="CalendarButtonFocused">
                                <Storyboard>
                                  <ObjectAnimationUsingKeyFrames Duration="0"
                                                                 Storyboard.TargetName="CalendarButtonFocusVisual"
                                                                 Storyboard.TargetProperty="Visibility">
                                    <DiscreteObjectKeyFrame KeyTime="0">
                                      <DiscreteObjectKeyFrame.Value>
                                        <Visibility>Visible</Visibility>
                                      </DiscreteObjectKeyFrame.Value>
                                    </DiscreteObjectKeyFrame>
                                  </ObjectAnimationUsingKeyFrames>
                                </Storyboard>
                              </VisualState>
                              <VisualState Name="CalendarButtonUnfocused" />
                            </VisualStateGroup>
                          </VisualStateManager.VisualStateGroups>
                <!-- ***************
                Sneaky bugger... looks like there is something called SelectedBackground
     (Rectangle) sitting here with a 0 opacity 
    waiting to be told to show himself. 
        Imagine that.
                -->
                          <Rectangle x:Name="SelectedBackground"
                                     RadiusX="1"
                                     RadiusY="1"
                                     Opacity="0">
                            <Rectangle.Fill>
                              <SolidColorBrush Color="{DynamicResource SelectedBackgroundColor}" />
                            </Rectangle.Fill>
                          </Rectangle>
                          <Rectangle x:Name="Background"
                                     RadiusX="1"
                                     RadiusY="1"
                                     Opacity="0">
                            <Rectangle.Fill>
                              <SolidColorBrush Color="{DynamicResource SelectedBackgroundColor}" />
                            </Rectangle.Fill>
                          </Rectangle>
                          <ContentPresenter x:Name="NormalText"
                                            HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                            VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                            Margin="1,0,1,1">
                            <TextElement.Foreground>
                              <SolidColorBrush Color="#FF333333" />
                            </TextElement.Foreground>
                          </ContentPresenter>
                          <Rectangle x:Name="CalendarButtonFocusVisual"
                                     Visibility="Collapsed"
                                     IsHitTestVisible="false"
                                     RadiusX="1"
                                     RadiusY="1">
                            <Rectangle.Stroke>
                              <SolidColorBrush Color="{DynamicResource SelectedBackgroundColor}" />
                            </Rectangle.Stroke>
                          </Rectangle>
                        </Grid>
                      </ControlTemplate>
                    </Setter.Value>
                  </Setter>
                  <Setter Property="Background">
                    <Setter.Value>
                      <SolidColorBrush Color="{DynamicResource ControlMediumColor}" />
                    </Setter.Value>
                  </Setter>
                </Style>
