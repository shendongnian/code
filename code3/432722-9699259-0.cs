      <Style TargetType="{x:Type Image}"
               x:Key="DropShadowImageStyle">
             <Setter Property="RenderTransform">
                <Setter.Value>
                    <ScaleTransform
                        ScaleX="1"
                        ScaleY="1" />
                </Setter.Value>
            </Setter>
            <Setter Property="Effect">
                <Setter.Value>
                    <DropShadowEffect
                        BlurRadius="20"
                        ShadowDepth="0" 
                        Opacity="0"
                        Color="{DynamicResource MyToColor}">
                    </DropShadowEffect>
                </Setter.Value>
            </Setter> 
            <Style.Triggers>
                <EventTrigger RoutedEvent="Image.MouseEnter">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation  
                                    Storyboard.TargetProperty="Effect.Opacity"
                                    From="0"
                                    To="1"                                     
                                    Duration="0:0:1">
                                </DoubleAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
                <EventTrigger RoutedEvent="Image.MouseLeave">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation
                                    Storyboard.TargetProperty="Effect.Opacity"
                                    From="1"
                                    To="0"
                                    Duration="0:0:1">
                                </DoubleAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
                <EventTrigger RoutedEvent="Image.MouseLeftButtonDown">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation
                                    Storyboard.TargetProperty="RenderTransform.ScaleX"
                                    From="1"
                                    To=".9"
                                    Duration="0:0:0.1">
                                </DoubleAnimation>
                                <DoubleAnimation
                                    Storyboard.TargetProperty="RenderTransform.ScaleY"
                                    From="1"
                                    To=".9"
                                    Duration="0:0:0.1">
                                </DoubleAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
                <EventTrigger RoutedEvent="Image.MouseLeftButtonUp">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation
                                    Storyboard.TargetProperty="RenderTransform.ScaleX"
                                    From=".9"
                                    To="1"
                                    Duration="0:0:0.1">
                                </DoubleAnimation>
                                <DoubleAnimation
                                    Storyboard.TargetProperty="RenderTransform.ScaleY"
                                    From=".9"
                                    To="1"
                                    Duration="0:0:0.1">
                                </DoubleAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
            </Style.Triggers>
        </Style>
     <StackPanel Orientation="Horizontal">
        <Image Source="MyImage1.JPG"
               Width="50" Height="50" Margin="5"
               Style="{StaticResource DropShadowImageStyle}">
            <Image.Resources>
                <Color x:Key="MyToColor">Red</Color>
            </Image.Resources>
        </Image>
        <Image Source="MyImage2.JPG"
               Width="50" Height="50" Margin="5"
               Style="{StaticResource DropShadowImageStyle}">
            <Image.Resources>
                <Color x:Key="MyToColor">Blue</Color>
            </Image.Resources>
        </Image>
        <Image Source="MyImage3.JPG"
               Width="50" Height="50" Margin="5"
               Style="{StaticResource DropShadowImageStyle}">
            <Image.Resources>
                <Color x:Key="MyToColor">Orange</Color>
            </Image.Resources>
        </Image>
    </StackPanel>
