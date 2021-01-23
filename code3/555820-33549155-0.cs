    <Style x:Key="ExpanderViewStyle" TargetType="toolkit:ExpanderView">
      <Setter Property="HorizontalAlignment" Value="Stretch"/>
      <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
      <Setter Property="ItemsPanel">
          <Setter.Value>
              <ItemsPanelTemplate>
                  <toolkit:WrapPanel/>
              </ItemsPanelTemplate>
          </Setter.Value>
      </Setter>
      <Setter Property="Template">
          <Setter.Value>
              <ControlTemplate TargetType="toolkit:ExpanderView">
                  <Grid>
                      <Grid.Resources>
                          <QuadraticEase x:Key="QuadraticEaseOut" EasingMode="EaseOut"/>
                          <QuadraticEase x:Key="QuadraticEaseInOut" EasingMode="EaseInOut"/>
                      </Grid.Resources>
                      <Grid.RowDefinitions>
                          <RowDefinition Height="Auto"/>
                          <RowDefinition Height="Auto"/>
                          <RowDefinition Height="Auto"/>
                      </Grid.RowDefinitions>
                      <VisualStateManager.VisualStateGroups>
                          <VisualStateGroup x:Name="ExpansionStates">
                              <VisualStateGroup.Transitions>
                                  <VisualTransition From="Collapsed" GeneratedDuration="0:0:0.15" To="Expanded">
                                      <Storyboard>
                                          <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Height)" Storyboard.TargetName="ItemsCanvas">
                                              <EasingDoubleKeyFrame EasingFunction="{StaticResource QuadraticEaseOut}" KeyTime="0:0:0.00" Value="0"/>
                                              <EasingDoubleKeyFrame x:Name="CollapsedToExpandedKeyFrame" EasingFunction="{StaticResource QuadraticEaseOut}" KeyTime="0:0:0.15" Value="1"/>
                                          </DoubleAnimationUsingKeyFrames>
                                          <DoubleAnimation Duration="0" To="1.0" Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="ItemsCanvas"/>
                                      </Storyboard>
                                  </VisualTransition>
                                  <VisualTransition From="Expanded" GeneratedDuration="0:0:0.15" To="Collapsed">
                                      <Storyboard>
                                          <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Height)" Storyboard.TargetName="ItemsCanvas">
                                              <EasingDoubleKeyFrame x:Name="ExpandedToCollapsedKeyFrame" EasingFunction="{StaticResource QuadraticEaseInOut}" KeyTime="0:0:0.00" Value="1"/>
                                              <EasingDoubleKeyFrame EasingFunction="{StaticResource QuadraticEaseInOut}" KeyTime="0:0:0.15" Value="0"/>
                                          </DoubleAnimationUsingKeyFrames>
                                          <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="ItemsCanvas">
                                              <EasingDoubleKeyFrame EasingFunction="{StaticResource QuadraticEaseInOut}" KeyTime="0:0:0.00" Value="1.0"/>
                                              <EasingDoubleKeyFrame EasingFunction="{StaticResource QuadraticEaseInOut}" KeyTime="0:0:0.15" Value="0.0"/>
                                          </DoubleAnimationUsingKeyFrames>
                                          <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="ItemsCanvas">
                                              <EasingDoubleKeyFrame EasingFunction="{StaticResource QuadraticEaseInOut}" KeyTime="0:0:0.00" Value="0.0"/>
                                              <EasingDoubleKeyFrame EasingFunction="{StaticResource QuadraticEaseInOut}" KeyTime="0:0:0.15" Value="-35"/>
                                          </DoubleAnimationUsingKeyFrames>
                                      </Storyboard>
                                  </VisualTransition>
                              </VisualStateGroup.Transitions>
                              <VisualState x:Name="Collapsed">
                                  <Storyboard>
                                      <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="(FrameworkElement.Height)" Storyboard.TargetName="ItemsCanvas"/>
                                      <DoubleAnimation Duration="0" To="0.0" Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="ItemsCanvas"/>
                                  </Storyboard>
                              </VisualState>
                              <VisualState x:Name="Expanded">
                                  <Storyboard>
                                      <DoubleAnimation Duration="0" Storyboard.TargetProperty="(FrameworkElement.Height)" Storyboard.TargetName="ItemsCanvas"/>
                                      <DoubleAnimation Duration="0" To="1.0" Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="ItemsCanvas"/>
                                  </Storyboard>
                              </VisualState>
                          </VisualStateGroup>
                          <VisualStateGroup x:Name="ExpandabilityStates">
                              <VisualState x:Name="Expandable"/>
                              <VisualState x:Name="NonExpandable">
                                  <Storyboard>
                                      <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="ExpandableContent">
                                          <DiscreteObjectKeyFrame KeyTime="0:0:0.0" Value="Collapsed"/>
                                      </ObjectAnimationUsingKeyFrames>
                                      <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="NonExpandableContent">
                                          <DiscreteObjectKeyFrame KeyTime="0:0:0.0" Value="Visible"/>
                                      </ObjectAnimationUsingKeyFrames>
                                  </Storyboard>
                              </VisualState>
                          </VisualStateGroup>
                      </VisualStateManager.VisualStateGroups>
                      <ListBoxItem x:Name="ExpandableContent" toolkit:TiltEffect.IsTiltEnabled="True" Grid.Row="0" Grid.RowSpan="2">
                          <Grid>
                              <Grid.RowDefinitions>
                                  <RowDefinition Height="Auto"/>
                                  <RowDefinition Height="Auto"/>
                                  <RowDefinition Height="Auto"/>
                              </Grid.RowDefinitions>
                              <ContentControl x:Name="Header" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" HorizontalAlignment="Stretch" HorizontalContentAlignment="Stretch" Grid.Row="0"/>
                              <ContentControl x:Name="Expander" ContentTemplate="{TemplateBinding ExpanderTemplate}" Content="{TemplateBinding Expander}" HorizontalAlignment="Stretch" HorizontalContentAlignment="Stretch" Grid.Row="1"/>
                              <Grid x:Name="ExpanderPanel" Background="Transparent" Grid.Row="0" Grid.RowSpan="2"/>
                          </Grid>
                      </ListBoxItem>
                                                
                      <ContentControl x:Name="NonExpandableContent" ContentTemplate="{TemplateBinding NonExpandableHeaderTemplate}" Content="{TemplateBinding NonExpandableHeader}" HorizontalAlignment="Stretch" HorizontalContentAlignment="Stretch" Grid.Row="0" Grid.RowSpan="2" Visibility="Collapsed"/>
                      <Canvas x:Name="ItemsCanvas" Opacity="0.0" Grid.Row="2">
                          <Canvas.RenderTransform>
                              <CompositeTransform TranslateY="0.0"/>
                          </Canvas.RenderTransform>
                          <ItemsPresenter x:Name="Presenter"/>
                      </Canvas>
                  </Grid>
              </ControlTemplate>
          </Setter.Value>
      </Setter>
    </Style>
