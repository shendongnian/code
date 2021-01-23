    <UserControl x:Class="MyApp.MyControl"
                 ...
                 xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
                 xmlns:l="clr-namespace:MyApp"
                 DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}">
        <UserControl.Resources>
            <Style TargetType="{x:Type l:MyControl}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type l:MyControl}">
                            <Border x:Name="brdBase" BorderThickness="1" BorderBrush="Cyan" Background="Black">
                                <Border.Resources>
                                    <Storyboard x:Key="MyStory">
                                        <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Border.BorderBrush).(SolidColorBrush.Color)" Storyboard.TargetName="brdBase">
                                            <SplineColorKeyFrame KeyTime="0:0:1" Value="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type l:MyControl}}, Path=SpecialColor}"/>
                                        </ColorAnimationUsingKeyFrames>
                                    </Storyboard>
                                </Border.Resources>
                                <i:Interaction.Triggers>
                                    <l:InteractiveTrigger Property="IsMouseOver" Value="True">
                                        <l:InteractiveTrigger.CommonActions>
                                            <BeginStoryboard Storyboard="{StaticResource MyStory}"/>
                                        </l:InteractiveTrigger.CommonActions>
                                    </l:InteractiveTrigger>
                                </i:Interaction.Triggers>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </UserControl.Resources>
    </UserControl>
