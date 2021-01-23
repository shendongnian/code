    <Grid>
            <Grid.Resources>
                <Storyboard x:Key="ShakeStatorMinorRadiusEdit">
                    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="RenderTransform.(TranslateTransform.X)"
                                                   RepeatBehavior="5x">
                        <EasingDoubleKeyFrame KeyTime="0:0:0.05"
                                              Value="0" />
                        <EasingDoubleKeyFrame KeyTime="0:0:0.1"
                                              Value="3" />
                        <EasingDoubleKeyFrame KeyTime="0:0:0.15"
                                              Value="0" />
                        <EasingDoubleKeyFrame KeyTime="0:0:0.20"
                                              Value="-3" />
                        <EasingDoubleKeyFrame KeyTime="0:0:0.25"
                                              Value="0" />
                    </DoubleAnimationUsingKeyFrames>
                </Storyboard>
            </Grid.Resources>
    
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
    
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>
    
            <TextBlock Grid.Column="1">Rotor</TextBlock>
            <TextBlock Grid.Column="2">Stator</TextBlock>
    
            <TextBlock Grid.Column="0"
                       Grid.Row="1">Lobes</TextBlock>
            <TextBlock Grid.Column="0"
                       Grid.Row="2">Major Radius</TextBlock>
            <TextBlock Grid.Column="0"
                       Grid.Row="3">Minor Radius</TextBlock>
    
            <TextBox Name="RotorLobes"
                     Grid.Column="1"
                     Grid.Row="1"
                     Text="1" />
            <TextBox Grid.Column="1"
                     Grid.Row="2" />
            <TextBox Name="MinorRadiusRotor"
                     Background="Blue"
                     Grid.Column="1"
                     Grid.Row="3" />
            
            <TextBox Grid.Column="2"
                     Grid.Row="1" />
            <TextBox Grid.Column="2"
                     Grid.Row="2" />
            <TextBox Name="MinorRadiusStator"
                     Background="Green"
                     Grid.Column="2"
                     Grid.Row="3">
                <TextBox.Style>
                    <Style>
                        <Style.Triggers>
                            <MultiDataTrigger>
                                <MultiDataTrigger.Conditions>
                                    <Condition Binding="{Binding ElementName=MinorRadiusRotor, Path=IsMouseOver}"
                                               Value="True" />
                                    <Condition Binding="{Binding ElementName=RotorLobes, Path=Text}}"
                                               Value="1" />
                                </MultiDataTrigger.Conditions>
                                <MultiDataTrigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource ShakeStatorMinorRadiusEdit}" />
                                </MultiDataTrigger.EnterActions>
                            </MultiDataTrigger>
                        </Style.Triggers>
                    </Style>
                </TextBox.Style>
            </TextBox>
    
        </Grid>
    
