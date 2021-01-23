      <Style x:Key="ValidatingTextBox" TargetType="TextBox">
        <Setter Property="FontFamily" Value="{StaticResource PhoneFontFamilyNormal}"/>
        <Setter Property="FontSize" Value="{StaticResource PhoneFontSizeMediumLarge}"/>
        <Setter Property="Background" Value="{StaticResource PhoneTextBoxBrush}"/>
        <Setter Property="Foreground" Value="{StaticResource PhoneTextBoxForegroundBrush}"/>
        <Setter Property="BorderBrush" Value="{StaticResource PhoneTextBoxBrush}"/>
        <Setter Property="SelectionBackground" Value="{StaticResource PhoneAccentBrush}"/>
        <Setter Property="SelectionForeground" Value="{StaticResource PhoneTextBoxSelectionForegroundBrush}"/>
        <Setter Property="BorderThickness" Value="{StaticResource PhoneBorderThickness}"/>
        <Setter Property="Padding" Value="2"/>
        <Setter Property="Template">
          <Setter.Value>
            <ControlTemplate TargetType="TextBox">
              <Grid Background="Transparent">
                <VisualStateManager.VisualStateGroups>
                  <VisualStateGroup x:Name="ValidationStates">
                    <VisualState x:Name="Valid" >
                      <Storyboard Duration="00:00:01">
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility"
                                           Storyboard.TargetName="WarningEllipse">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Collapsed</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility"
                                           Storyboard.TargetName="WarningText">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Collapsed</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                    <VisualState x:Name="InvalidUnfocused">
                      <Storyboard Duration="00:00:01">
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility"
                                           Storyboard.TargetName="WarningEllipse">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Visible</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <!-- note the warning text is not shown if unfocused -->
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility"
                                           Storyboard.TargetName="WarningText">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Collapsed</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                    <VisualState x:Name="InvalidFocused">
                      <Storyboard>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility"
                                           Storyboard.TargetName="WarningText">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Visible</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility"
                                           Storyboard.TargetName="WarningEllipse">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Visible</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                  </VisualStateGroup>
                  <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal"/>
                    <VisualState x:Name="MouseOver"/>
                    <VisualState x:Name="Disabled">
                      <Storyboard>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="EnabledBorder">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Collapsed</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DisabledOrReadonlyBorder">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Visible</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                    <VisualState x:Name="ReadOnly">
                      <Storyboard>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="EnabledBorder">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Collapsed</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DisabledOrReadonlyBorder">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Visible</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="DisabledOrReadonlyBorder">
                          <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxBrush}"/>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="DisabledOrReadonlyBorder">
                          <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxBrush}"/>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="DisabledOrReadonlyContent">
                          <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxReadOnlyBrush}"/>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                  </VisualStateGroup>
                  <VisualStateGroup x:Name="FocusStates">
                    <VisualState x:Name="Focused">
                      <Storyboard>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="EnabledBorder">
                          <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxEditBackgroundBrush}"/>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="EnabledBorder">
                          <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxEditBorderBrush}"/>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                    <VisualState x:Name="Unfocused"/>
                  </VisualStateGroup>
                </VisualStateManager.VisualStateGroups>
                <Border x:Name="EnabledBorder"
                      BorderBrush="{TemplateBinding BorderBrush}"
                      BorderThickness="{TemplateBinding BorderThickness}"
                      Background="{TemplateBinding Background}" Margin="{StaticResource PhoneTouchTargetOverhang}">
                  <Grid>
                    <Grid.RowDefinitions>
                      <RowDefinition Height="Auto" />
                      <RowDefinition Height="Auto"/>
                    </Grid.RowDefinitions>
                    <ContentControl Grid.Row="0" x:Name="ContentElement" BorderThickness="0" HorizontalContentAlignment="Stretch"
                            Margin="{StaticResource PhoneTextBoxInnerMargin}"
                            Padding="{TemplateBinding Padding}"
                            VerticalContentAlignment="Top"/>
                    <Ellipse Grid.Row="0"
                        x:Name="WarningEllipse"  Visibility="Collapsed"
                        Margin="12,12,12,0"
                        VerticalAlignment="Top"
                        HorizontalAlignment="Right"
                        Width="14" Height="14"
                        Stroke="#40000000" StrokeThickness="2" Fill="Red">
                    </Ellipse>
                    <TextBlock x:Name="WarningText" Grid.Row="1" Foreground="Red"  Visibility="Collapsed" TextWrapping="Wrap"
                            Margin="3,-12,3,0"
                             Text="{Binding RelativeSource={RelativeSource TemplatedParent}, 
                                  Path=(Validation.Errors)[0].ErrorContent, FallbackValue=''}"></TextBlock>
                  </Grid>
                </Border>
                <Border x:Name="DisabledOrReadonlyBorder" BorderBrush="{StaticResource PhoneDisabledBrush}"
                      BorderThickness="{TemplateBinding BorderThickness}" Background="Transparent"
                      Margin="{StaticResource PhoneTouchTargetOverhang}" Visibility="Collapsed">
                  <TextBox x:Name="DisabledOrReadonlyContent"
                         Background="Transparent"
                         Foreground="{StaticResource PhoneDisabledBrush}"
                         FontWeight="{TemplateBinding FontWeight}" FontStyle="{TemplateBinding FontStyle}"
                         FontSize="{TemplateBinding FontSize}" FontFamily="{TemplateBinding FontFamily}"
                         IsReadOnly="True" SelectionForeground="{TemplateBinding SelectionForeground}"
                         SelectionBackground="{TemplateBinding SelectionBackground}" TextAlignment="{TemplateBinding TextAlignment}"
                         TextWrapping="{TemplateBinding TextWrapping}" Text="{TemplateBinding Text}"
                         Template="{StaticResource PhoneDisabledTextBoxTemplate}"/>
                </Border>
              </Grid>
            </ControlTemplate>
          </Setter.Value>
        </Setter>
      </Style>
