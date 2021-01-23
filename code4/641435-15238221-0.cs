    <Window x:Class="SlidingWrapPanel.SecondAttempt"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:SlidingWrapPanel"
            Title="Wrapped items with details pane" Height="250" Width="600">
        <Window.Resources>
            <ControlTemplate TargetType="Button" x:Key="ItemButtonTemplate">
                <ControlTemplate.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation Storyboard.TargetName="ButtonBorder"
                                                Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)"
                                                To="#999999" Duration="0:0:0.5" />
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                        <Trigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation Storyboard.TargetName="ButtonBorder"
                                                Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)"
                                                To="#3e3e3e" Duration="0:0:0.5" />
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.ExitActions>
                    </Trigger>
                </ControlTemplate.Triggers>
                <Border x:Name="ButtonBorder" Background="#3e3e3e" BorderBrush="#222" BorderThickness="1">
                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" Content="{TemplateBinding Content}" Margin="0" />
                </Border>
            </ControlTemplate>
            <Style x:Key="ItemGridStyle" TargetType="{x:Type Grid}">
                <Setter Property="Background" Value="#3e3e3e"/>
                <Setter Property="Width" Value="150"/>
                <Setter Property="Height" Value="100"/>
                <Setter Property="Margin" Value="1"/>
            </Style>
            <Style x:Key="ItemButtonStyle" TargetType="{x:Type Button}">
                <Setter Property="Foreground" Value="White"/>
                <Setter Property="HorizontalContentAlignment" Value="Center"/>
                <Setter Property="VerticalContentAlignment" Value="Center"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <Binding Source="{StaticResource ItemButtonTemplate}"/>
                    </Setter.Value>
                </Setter>
            </Style>
            <Style x:Key="DetailsGridStyle" TargetType="{x:Type Grid}">
                <Setter Property="Background" Value="#3e3e3e"/>
                <Setter Property="Width" Value="160"/>
                <Setter Property="HorizontalAlignment" Value="Left"/>
                <Setter Property="RenderTransform">
                    <Setter.Value>
                        <TranslateTransform X="-160" />
                    </Setter.Value>
                </Setter>
            </Style>
            <Style x:Key="DetailsTextStyle" TargetType="{x:Type TextBlock}">
                <Setter Property="Foreground" Value="White"/>
                <Setter Property="FontFamily" Value="Segoe WP Light"/>
                <Setter Property="Margin" Value="15"/>
            </Style>
            <Storyboard x:Key="ExpandColumnAnimation">
                <DoubleAnimation Storyboard.TargetProperty="GapWidth" Storyboard.TargetName="ItemsPanel"
                                 From="0" To="{Binding ActualWidth, ElementName=DetailsPanel}" Duration="0:0:0.75">
                    <DoubleAnimation.EasingFunction>
                        <QuinticEase EasingMode="EaseOut"/>
                    </DoubleAnimation.EasingFunction>
                </DoubleAnimation>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TranslateTransform.X)"
                                               Storyboard.TargetName="DetailsPanel">
                    <DiscreteDoubleKeyFrame KeyTime="0" Value="{Binding GapX, ElementName=ItemsPanel}"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
            <Storyboard x:Key="CollapseColumnAnimation">
                <DoubleAnimation Storyboard.TargetProperty="GapWidth" Storyboard.TargetName="ItemsPanel"
                                 To="0" Duration="0:0:0.5">
                    <DoubleAnimation.EasingFunction>
                        <QuinticEase EasingMode="EaseIn"/>
                    </DoubleAnimation.EasingFunction>
                </DoubleAnimation>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TranslateTransform.X)"
                                               Storyboard.TargetName="DetailsPanel">
                    <DiscreteDoubleKeyFrame KeyTime="0:0:0.5" Value="-160"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Window.Resources>
        <Grid>
            <Grid>
                <Grid x:Name="DetailsPanel" Style="{StaticResource DetailsGridStyle}">
                    <ScrollViewer>
                        <TextBlock Style="{StaticResource DetailsTextStyle}">
                            <Run Text="Details" FontSize="18"/>
                            <LineBreak />
                            <Run Text="Some text"/>
                        </TextBlock>
                    </ScrollViewer>
                </Grid>
            </Grid>
            <local:GapPanel x:Name="ItemsPanel">
                <local:GapPanel.Triggers>
                    <EventTrigger RoutedEvent="local:GapPanel.ColumnChanged">
                        <BeginStoryboard Storyboard="{StaticResource ExpandColumnAnimation}"/>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="local:GapPanel.CloseGap">
                        <BeginStoryboard Storyboard="{StaticResource CollapseColumnAnimation}"/>
                    </EventTrigger>
                </local:GapPanel.Triggers>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 1" />
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 2" />
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 3" />
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 4"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 5"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 6"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 7"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 8"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 9"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 10"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 11"/>
                </Grid>
                <Grid Style="{StaticResource ItemGridStyle}">
                    <Button Style="{StaticResource ItemButtonStyle}" Content="Item 12"/>
                </Grid>
            </local:GapPanel>
        </Grid>
    </Window>
