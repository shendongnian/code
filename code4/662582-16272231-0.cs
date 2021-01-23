        <Grid>
        <Grid.Resources>
            <Style x:Key="CategoryButtonStyle" TargetType="{x:Type Button}">
                <Setter Property="HorizontalContentAlignment" Value="Center"/>
                <Setter Property="VerticalContentAlignment" Value="Center"/>
                <Setter Property="Padding" Value="1"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type Button}">
                            <Border Background="Green" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" x:Name="root">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal" />
                                        <VisualState x:Name="TestState">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="root" 
                                   Storyboard.TargetProperty="Background.(SolidColorBrush.Color)">
                                                    <DiscreteObjectKeyFrame KeyTime="0" >
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Color>Red</Color>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Selected">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="TabPath" 
                                   Storyboard.TargetProperty="Fill">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="#FFe4f6fa" />
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Grid x:Name="grid">
                                    <ContentPresenter x:Name="buttonContent" Margin="10,2,10,2" VerticalAlignment="Center"
                                      TextElement.Foreground="{TemplateBinding Foreground}"/>
                                </Grid>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        <Button x:Name="test" Style="{StaticResource CategoryButtonStyle}" Content="Test"  VerticalAlignment="Center" Width="200px" BorderBrush="#888" BorderThickness="1px"/>
    </Grid>
