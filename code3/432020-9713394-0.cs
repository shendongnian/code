    <Style x:Key="NoSelectListBoxItemStyle" TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem">
                            <Border x:Name="LayoutRoot" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" HorizontalAlignment="{TemplateBinding HorizontalAlignment}" VerticalAlignment="{TemplateBinding VerticalAlignment}">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="MouseOver"/>
                                        <VisualState x:Name="Disabled">
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="SelectionStates">
                                        <VisualState x:Name="Unselected">
                                            <Storyboard>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="ContentContainer">
                                                    <SplineDoubleKeyFrame KeyTime="0" Value="1"/>
                                                </DoubleAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Selected"/>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <ContentControl x:Name="ContentContainer" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" Foreground="{StaticResource Dark_Foreground}" HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}" d:LayoutOverrides="Width"/>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
